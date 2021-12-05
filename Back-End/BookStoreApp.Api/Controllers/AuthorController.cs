using BookStoreApp.Application.Authors.AuthorDTOs;
using BookStoreApp.Application.Authors.Commands;
using BookStoreApp.Application.Authors.Commands.DeleteAuthor;
using BookStoreApp.Application.Authors.Commands.UpdateAuthor;
using BookStoreApp.Application.Authors.Queries.GetAuthor;
using BookStoreApp.Application.Authors.Queries.GetAuthors;
using BookStoreApp.Application.DTOs.AuthorDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Api.Controllers
{
    public class AuthorController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorListDto>>> Get()
        {
            return await Mediator.Send(new GetAuthorsQuery());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<AuthorDto>> Get([FromRoute] GetAuthorQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post(CreateAuthorCommand command)
        {
            Guid authorId = await Mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = authorId }, null);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateAuthorCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteAuthorCommand { Id = id });
            return Ok();
        }
    }
}
