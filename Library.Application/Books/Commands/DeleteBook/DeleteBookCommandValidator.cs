﻿using FluentValidation;


namespace Library.Application.Books.Commands.DeleteBook
{
    public  class DeleteBookCommandValidator: AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(deleteBookCommand => deleteBookCommand.Id).NotEqual(Guid.Empty);
        }
    }
}