using ToDoApp.Core.Models;
using FluentValidation;
using ToDoApp.API.DTOs.ToDoItem;

namespace ToDoApp.API.Validation
{
    public class ToDoItemCreateValidator : AbstractValidator<ToDoItemCreate>
    {
        public ToDoItemCreateValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("This field is required!");
            RuleFor(p => p.Name).MaximumLength(200).WithMessage("This field cannot higher than 200 character!");
        }
    }
}
