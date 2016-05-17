using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MethodImmo.Model
{
    public class ResultObject
    {
        public HttpStatusCode Status;

        public string Message;

        public string TechnicalMessage;

        public ResultObject(HttpStatusCode status, string message="OK", string technical = "")
        {
            Status = status;
            Message = message;
            TechnicalMessage = technical;
        }
    }
}
