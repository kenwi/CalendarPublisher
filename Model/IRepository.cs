using Microsoft.Exchange.WebServices.Data;
using System.Collections.Generic;

namespace Model
{
    public interface IRepository
    {
        IEnumerable<Appointment> All();
    }
}
