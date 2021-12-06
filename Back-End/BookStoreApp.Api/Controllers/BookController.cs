using BookStoreApp.Application.Authors.Commands.DeleteAuthor;
using BookStoreApp.Application.Books.BooksDTOs;
using BookStoreApp.Application.Books.Commands;
using BookStoreApp.Application.Books.Commands.UpdateBook;
using BookStoreApp.Application.Books.Queries;
using BookStoreApp.Application.Books.Queries.GetBook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Api.Controllers
{
    public class BookController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookListDto>>> Get()
        {
            return await Mediator.Send(new GetBooksQuery());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<BookDto>> Get([FromRoute] GetBookQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] CreateBookCommand command)
        {
            Guid bookId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = bookId }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] UpdateBookCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteBookCommand { Id = id });
            return Ok();
        }
    }
}
