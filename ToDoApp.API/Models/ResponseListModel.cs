using System.Collections.Generic;

namespace ToDoApp.API.Models
{
    public class ResponseListModel<T> : IResponseListModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public IList<T> Response { get; set; }
    }
}
