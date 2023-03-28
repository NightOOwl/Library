using AutoMapper;
using Library.Application.Authors.Commands.AddAuthor;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Mappings;

namespace Library.WebApi.Models
{
    public class AddAuthorDto: IMapWith<AddAuthorCommand>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddAuthorDto, AddAuthorCommand>()
                .ForMember(authorCommand => authorCommand.FirstName,
                    opt => opt.MapFrom(bookDto => bookDto.FirstName));
            profile.CreateMap<AddAuthorDto, AddAuthorCommand>()
                .ForMember(authorCommand => authorCommand.LastName,
                    opt => opt.MapFrom(bookDto => bookDto.LastName));
        }
    }
}
