using AutoMapper;
using Lib.Domain;
using Library.Application.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Books.Queries.GetBookList
{
    public  class BookLookUpDto: IMapWith<Book>
    {
        public Guid Id { get; set; } 
        public string Title { get; set; }
        public void Mapping (Profile profile)
        {
            profile.CreateMap<Book,BookLookUpDto>()
                .ForMember(bookDto=>bookDto.Id,
                    opt=>opt.MapFrom(book=>book.Id))

               .ForMember(bookDto => bookDto.Title,
                    opt => opt.MapFrom(book => book.Title));
        }
    }
}
