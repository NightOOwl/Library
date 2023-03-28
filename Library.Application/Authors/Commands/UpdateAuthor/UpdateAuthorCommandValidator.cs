using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator: AbstractValidator<UpdateAuthorCommand>
    {
        UpdateAuthorCommandValidator()
        {
            RuleFor(updateAuthorCommand => updateAuthorCommand.Id).NotEqual(Guid.Empty);
            RuleFor(addAuthorCommand => addAuthorCommand.FirstName)
                .NotEmpty().MaximumLength(30);
            RuleFor(addAuthorCommand => addAuthorCommand.LastName)
                .NotEmpty().MaximumLength(30);
            RuleFor(addAuthorCommand => addAuthorCommand.Country).NotEmpty();
        }
    }
}
