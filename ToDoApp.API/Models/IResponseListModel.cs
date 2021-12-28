using System.Collections.Generic;

namespace ToDoApp.API.Models
{
    public interface IResponseListModel<T>
    {
        bool Success { get; set; }
        string Message { get; set; }
        int StatusCode { get; set; }
        IList<T> Response { get; set; }
    }
}
