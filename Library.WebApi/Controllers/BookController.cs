using AutoMapper;
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
    public class BookController : BaseController
    {
        private readonly IMapper _mapper;   
        public BookController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<BookListVm>> GetAll()
        {
            var query = new GetBookListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BookVm>> Get(Guid id)
        {
            var query = new GetBookQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async  Task <ActionResult<Guid>> Create([FromBody] CreateBookDto createBookDto)
        {
            var command = _mapper.Map<CreateBookCommand>(createBookDto);
            var bookId = await Mediator.Send(command);
            return Ok(bookId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBookDto updateBookDto)
        {
            var command = _mapper.Map<UpdateBookCommand>(updateBookDto);
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (Guid id)
        {
            var command = new DeleteBookCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }


    }
}
