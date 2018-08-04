using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.ViewModels.Validations
{
    public class ContactViewModelValidator: AbstractValidator<ContactViewModel>
    {
        public ContactViewModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName cannot be empty");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName cannot be empty");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber cannot be empty");
        }
    }
}
