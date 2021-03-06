﻿using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Exchange.WebServices.Data;

namespace Model
{
    /// <summary>
    /// This class will use autodiscovery to start up it's exchange service, use impersonation to 
    /// authenticate as a given user X and get the appointments from a shared calendar from user Y
    /// </summary>
    public class AppointmentRepository : IRepository
    {
        private readonly CalendarView _calendarView;
        private readonly CalendarFolder _calendarFolder;

        private readonly string _userToImpersonate = Properties.Settings.Default.ImpersonateEmail;
        private readonly string _userWhoSharedCalendar = Properties.Settings.Default.SharedCalendarEmail;
        private readonly DateTime _daysBefore = DateTime.Now.AddDays(-Properties.Settings.Default.DaysBefore);
        private readonly DateTime _daysAfter = DateTime.Now.AddDays(Properties.Settings.Default.DaysAfter);
        
        public AppointmentRepository()
        {
            var _service = new ExchangeService
            {
                UseDefaultCredentials = true
            };
            _service.AutodiscoverUrl(_userToImpersonate);

            var folderId = new FolderId(WellKnownFolderName.Calendar, _userWhoSharedCalendar);
            _calendarFolder = CalendarFolder.Bind(_service, folderId);
            _calendarView = new CalendarView(_daysBefore, _daysAfter)
            {
                PropertySet = new PropertySet(
                    AppointmentSchema.Subject, 
                    AppointmentSchema.Start, 
                    AppointmentSchema.Duration)
            };
        }
        
        public PropertySet CalendarProperties
        {
            set { _calendarView.PropertySet = value; }
        }
        
        public IEnumerable<Appointment> All()
        {
            return _calendarFolder.FindAppointments(_calendarView).Where(appointment => appointment.Subject.Contains("Private"));
        }
    }
}
