using Microsoft.Exchange.WebServices.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CalendarView
{
    public class ConsoleViewMain : ViewMain
    {
        public ConsoleViewMain()
        {

        }

        public override List<Appointment> Appointments
        {
            get
            {
                return _presenter.GetAppointments();
            }
        }

        public override void Run()
        {
            Console.WriteLine("**Calendar Appointments**");
            foreach( var appointment in Appointments)
            {
                Console.WriteLine($"Subject: {appointment.Subject}");
                Console.WriteLine($"Start: {appointment.Start}");
                Console.WriteLine($"Duration: {appointment?.Duration}");
                                
                Console.WriteLine();
            }
            Console.ReadKey();
        }


    }
}