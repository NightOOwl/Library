using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand: IRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateTime EditTime { get; set; }
        public string Country { get; set; }
    }
}
