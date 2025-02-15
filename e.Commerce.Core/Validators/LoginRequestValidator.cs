using e.Commerce.Core.DTO;
using FluentValidation;


namespace e.Commerce.Core.Validators;

public class LoginRequestValidator:AbstractValidator<LoginRequest>
{

    // this will call automatically on validation
    public LoginRequestValidator()
    {
        RuleFor(temp => temp.Email)
           .NotEmpty().WithMessage("Email is Required")
           .EmailAddress()
           .WithMessage("Inavlid email address format");

        RuleFor(temp => temp.Password)
           .NotEmpty()
           .WithMessage("Password is required")
      ;
    }
}
