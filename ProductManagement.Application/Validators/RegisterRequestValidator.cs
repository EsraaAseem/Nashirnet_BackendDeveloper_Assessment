// Application/Validators/RegisterRequestValidator.cs
using FluentValidation;
using ProductManagement.Application.Models.AuthModels;
using ProductManagement.Domain.Enums;

namespace ProductManagement.Application.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.");

            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("Role is required.");
        }

       
    }
}