using System;

namespace Lib.Domain
{
    public class Author
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public  DateOnly BirthDate { get; set; }
        public DateTime? EditTime { get; set; }
        public string Country { get; set; } 
    }
}
