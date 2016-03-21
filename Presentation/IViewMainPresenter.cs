using Microsoft.Exchange.WebServices.Data;
using System.Collections.Generic;

namespace Presentation
{
    public interface IViewMainPresenter : IPresenter<IViewMain>
    {
        List<Appointment> GetAppointments();
    }
}