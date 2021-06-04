using Dotz.Application.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Infrastructure.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Por favor, insira um e-mail válido");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Por favor, insira um e-mail");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Por favor, insira uma senha");
        }
    }
}
