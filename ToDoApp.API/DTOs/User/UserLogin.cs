using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.API.DTOs.User
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
