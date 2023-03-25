using AutoMapper;
using Lib.Domain;
using Library.Application.Mappings;


namespace Library.Application.Authors.Queries.GetAuthor
{
    public class AuthorVm: IMapWith<Author>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateTime? EditDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorVm>()
                .ForMember(authorVm => authorVm.FirstName,
                        opt => opt.MapFrom(author => author.FirstName))

                  .ForMember(authorVm => authorVm.LastName,
                        opt => opt.MapFrom(author => author.LastName))

                   .ForMember(authorVm => authorVm.EditDate,
                        opt => opt.MapFrom(author => author.EditTime))

                    .ForMember(authorVm => authorVm.Id,
                        opt => opt.MapFrom(author => author.Id))

                    .ForMember(authorVm => authorVm.Country,
                        opt => opt.MapFrom(author => author.Country))

                    .ForMember(authorVm => authorVm.BirthDate,
                        opt => opt.MapFrom(author => author.BirthDate));
        }
    }
}
