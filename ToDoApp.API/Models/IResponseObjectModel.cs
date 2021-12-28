namespace ToDoApp.API.Models
{
    public interface IResponseObjectModel<T>
    {
        bool Success { get; set; }
        string Message { get; set; }
        int StatusCode { get; set; }
        T Response { get; set; }
    }
}
