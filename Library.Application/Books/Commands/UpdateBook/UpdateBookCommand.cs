using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand: IRequest
    {
        public Guid  Id { get; set; }   
        public Guid AuthorId { get;set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
