using System.Collections.Generic;
using System.Linq;
using Microsoft.Exchange.WebServices.Data;
using Model;
using Model.Extensions;

namespace Presentation
{
    public class ViewMainPresenter : IViewMainPresenter
    {
        private readonly IViewMain _view;
        private AppointmentRepository _repository;

        public ViewMainPresenter(IViewMain view)
        {
            _view = view;
            _view.Presenter = this;
            _repository = new AppointmentRepository();
        }

        public IViewMain View
        {
            get
            {
                return _view;
            }
        }

        public List<Appointment> GetAppointments()
        {
            return _repository.All().ToList();
        }

        public void Run()
        {
            _view.Run();            
        }
    }
}
