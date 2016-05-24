using System.Net;

namespace MethodImmo.Services.ViewModels
{
    public class ResultObject
    {
        public ResultObject(HttpStatusCode status,string message,string techique)
        {
            Status = status;
            Message = message;
            Technique = techique;
        }

        public HttpStatusCode Status;
        public string Message;
        public string Technique;
    }
}