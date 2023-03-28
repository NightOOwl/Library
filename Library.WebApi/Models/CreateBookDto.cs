using AutoMapper;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Mappings;

namespace Library.WebApi.Models
{
    public class CreateBookDto: IMapWith<CreateBookCommand>
    {
        public string Title { get; set; }   
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBookDto,CreateBookCommand>()
                .ForMember(bookCommand=> bookCommand.Title,
                    opt=>opt.MapFrom(bookDto=>bookDto.Title));
        }
    }
}
