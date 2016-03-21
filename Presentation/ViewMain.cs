using System;
using Presentation;
using Microsoft.Exchange.WebServices.Data;
using System.Collections.Generic;

namespace CalendarView
{
    public abstract class ViewMain : IViewMain
    {
        protected IViewMainPresenter _presenter;
                
        public IViewMainPresenter Presenter
        {
            get
            {
                return _presenter;
            }

            set
            {
                if (_presenter == null)
                    _presenter = value;
            }
        }

        public abstract void Run();     
        public abstract List<Appointment> Appointments { get; }
    }
}