using ToDoApp.Core.Models;
using FluentValidation;

namespace ToDoApp.API.Validation
{
    public class ToDoListValidator : AbstractValidator<ToDoList>
    {
        public ToDoListValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("This field is required!");
        }
    }
}
