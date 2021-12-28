namespace ToDoApp.API.Models
{
    public class ResponseObjectModel<T> : IResponseObjectModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T Response { get; set; }
    }
}
