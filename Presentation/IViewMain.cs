using Microsoft.Exchange.WebServices.Data;
using System.Collections.Generic;

namespace Presentation
{
    public interface IViewMain : IView<IViewMainPresenter>
    {
        List<Appointment> Appointments { get; }
    }
}