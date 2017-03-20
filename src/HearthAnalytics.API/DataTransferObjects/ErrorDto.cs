using Newtonsoft.Json;

namespace HearthAnalytics.API.DataTransferObjects
{
    public class ErrorDto
    {
        public int Code { get; set; }

        public string ExceptionType { get; set; }

        public string ExceptionMessage { get; set; }

        public string InnerExceptionMessage { get; set; }

        public string StackTrace { get; set; }

        public string Source { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
