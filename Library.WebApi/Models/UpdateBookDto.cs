using AutoMapper;
using Library.Application.Books.Commands.UpdateBook;
using Library.Application.Mappings;

namespace Library.WebApi.Models
{
    public class UpdateBookDto: IMapWith<UpdateBookCommand>
    {
        public Guid Id { get; set; }    
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public DateOnly PublicationDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBookDto, UpdateBookCommand>()
                .ForMember(bookCommand => bookCommand.Id,
                    opt => opt.MapFrom(bookDto => bookDto.Id))

                .ForMember(bookCommand => bookCommand.Title,
                    opt => opt.MapFrom(bookDto => bookDto.Title))

                .ForMember(bookCommand => bookCommand.AuthorId,
                    opt => opt.MapFrom(bookDto => bookDto.AuthorId))

                .ForMember(bookCommand => bookCommand.PublicationDate,
                    opt => opt.MapFrom(bookDto => bookDto.PublicationDate));
        }
    }
}
