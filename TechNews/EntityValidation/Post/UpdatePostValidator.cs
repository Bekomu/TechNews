using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.DTOs.Posts;

namespace TechNews.Business.EntityValidation.Post
{
    public class UpdatePostValidator : AbstractValidator<PostUpdateDTO>
    {
        readonly string notNull = "This value is required";

        public UpdatePostValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage(notNull)
                .NotNull().WithMessage(notNull);

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(notNull)
                .NotNull().WithMessage(notNull);

            RuleFor(x => x.ImageURL)
                .NotEmpty().WithMessage(notNull)
                .NotNull().WithMessage(notNull);
        }

    }
}
