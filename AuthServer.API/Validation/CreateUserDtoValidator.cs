using FluentValidation;
using UdemyAuthServer.Core.DTOs;

namespace UdemyAuthServer.API.Validation
{
    public class CreateUserDtoValidator:AbstractValidator <CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is Required").EmailAddress().WithMessage("Email is wrong");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is requied");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");


        }


    }
}
