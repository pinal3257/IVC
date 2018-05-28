using System;

namespace IVC.Return
{
    public class Response<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public T Content { get; set; }
    }

    public class Response
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
     
}
