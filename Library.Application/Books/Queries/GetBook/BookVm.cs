using AutoMapper;
using Lib.Domain;
using Library.Application.Mappings;


namespace Library.Application.Books.Queries.GetBooks
{
    public  class BookVm: IMapWith<Book>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }  
        public DateOnly PublicationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public void Mapping (Profile profile)
        {
            profile.CreateMap<Book, BookVm>()
                .ForMember(bookVm => bookVm.Title,
                        opt => opt.MapFrom(book => book.Title))

                  .ForMember(bookVm => bookVm.PublicationDate,
                        opt => opt.MapFrom(book => book.PublicationDate))

                   .ForMember(bookVm => bookVm.EditDate,
                        opt => opt.MapFrom(book => book.EditTime))

                    .ForMember(bookVm => bookVm.Id,
                        opt => opt.MapFrom(book => book.Id));
        }
    }
}
