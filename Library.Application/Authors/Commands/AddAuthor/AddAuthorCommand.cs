using MediatR;

namespace Library.Application.Authors.Commands.AddAuthor
{
    public class AddAuthorCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public DateOnly BirthDate { get; set; } 
        public string Country { get; set; }
        public DateTime EditTime { get; set; }
    }
}
