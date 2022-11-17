using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Dtos.Admins;

namespace TechNews.Business.EntityValidation.Admin
{
    public class CreateAdminValidator : AbstractValidator<AdminCreateDTO>, IDateValidator
    {
        readonly string notNull = "This value is required";
        readonly string wrongDate = "Please enter valid date.";
        readonly string wrongEmail = "Please enter valid email.";

        public CreateAdminValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(notNull)
                .NotNull().WithMessage(notNull);

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage(notNull)
                .NotNull().WithMessage(notNull);

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(notNull)
                .NotNull().WithMessage(notNull);

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage(notNull)
                .NotNull().WithMessage(notNull)
                .Must(BeAValidDate).WithMessage(wrongDate);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(notNull)
                .NotNull().WithMessage(notNull)
                .EmailAddress().WithMessage(wrongEmail);
        }

        public bool BeAValidDate<T>(T date)
        {
            return !date.Equals(default(T));
        }
    }
}
