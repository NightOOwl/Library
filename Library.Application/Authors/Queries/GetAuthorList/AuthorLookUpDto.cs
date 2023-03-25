using AutoMapper;
using Lib.Domain;
using Library.Application.Mappings;

namespace Library.Application.Authors.Queries.GetAuthorList
{
    public class AuthorLookUpDto: IMapWith<Author>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorLookUpDto>()
                .ForMember(authorDto => authorDto.Id,
                    opt => opt.MapFrom(author => author.Id))

               .ForMember(authorDto => authorDto.FirstName,
                    opt => opt.MapFrom(author => author.FirstName))

              .ForMember(authorDto => authorDto.LastName,
                    opt => opt.MapFrom(author => author.LastName));
        }
    }
}
