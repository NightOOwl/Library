using AutoMapper;
using Library.Application.Authors.Commands.AddAuthor;
using Library.Application.Authors.Commands.DeleteAuthor;
using Library.Application.Authors.Commands.UpdateAuthor;
using Library.Application.Authors.Queries.GetAuthor;
using Library.Application.Authors.Queries.GetAuthorList;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Books.Commands.DeleteBook;
using Library.Application.Books.Commands.UpdateBook;
using Library.Application.Books.Queries.GetBookList;
using Library.Application.Books.Queries.GetBooks;
using Library.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : BaseController
    {
        private readonly IMapper _mapper;
        public AuthorController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<AuthorListVm>> GetAll()
        {
            var query = new GetAuthorListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorVm>> Get(Guid id)
        {
            var query = new GetAuthorQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] AddAuthorDto createAuthorDto)
        {
            var command = _mapper.Map<AddAuthorCommand>(createAuthorDto);
            var AuthorId = await Mediator.Send(command);
            return Ok(AuthorId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAuthorDto updateAuthorDto)
        {
            var command = _mapper.Map<UpdateAuthorCommand>(updateAuthorDto);
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteAuthorCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }


    }
}
