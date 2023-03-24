using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Guid>
    {
        public Guid AuthorId { get; set; }
        public string Title { get; set; }   
        public string Author { get; set; }
    }
}
