using AutoMapper;
using Library.Application.Authors.Commands.UpdateAuthor;
using Library.Application.Books.Commands.UpdateBook;
using Library.Application.Mappings;

namespace Library.WebApi.Models
{
    public class UpdateAuthorDto: IMapWith<UpdateAuthorCommand>
    {
        public Guid Id { get; set; }
        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateOnly BirthDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAuthorDto, UpdateAuthorCommand>()
                .ForMember(authorCommand => authorCommand.Id,
                    opt => opt.MapFrom(authorDto => authorDto.Id))

                .ForMember(authorCommand => authorCommand.FirstName,
                    opt => opt.MapFrom(authorDto => authorDto.FirstName))

                .ForMember(authorCommand => authorCommand.LastName,
                    opt => opt.MapFrom(authorDto => authorDto.LastName))

                .ForMember(authorCommand => authorCommand.Country,
                    opt => opt.MapFrom(authorDto => authorDto.Country))

                .ForMember(authorCommand => authorCommand.BirthDate,
                    opt => opt.MapFrom(authorDto => authorDto.BirthDate));
        }
    }
}
