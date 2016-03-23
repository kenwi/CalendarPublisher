using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Extensions
{
    public static class AppointmentExtension
    {
        public static string ToHtml(this List<Appointment> appointments)
        {
            return "Converted to html";
        }
    }
}
