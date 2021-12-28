using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using ToDoApp.API.Models;

namespace ToDoApp.API.Extensions
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error;

                        var responseModel = new ResponseObjectModel<string>();
                        responseModel.Success = false;
                        responseModel.StatusCode = 500;
                        responseModel.Message = ex.Message;
                        responseModel.Response = string.Empty;

                        await context.Response.WriteAsync(JsonSerializer.Serialize(responseModel));
                    }
                });
            });
        }
    }
}
