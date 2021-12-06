using BookStoreApp.Application.Comments.Commands;
using BookStoreApp.Application.Comments.Commands.CreateBookComment;
using BookStoreApp.Application.Comments.CommentDTOs;
using BookStoreApp.Application.Comments.Queries.GetAuthorComments;
using BookStoreApp.Application.Comments.Queries.GetBookComments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Api.Controllers
{
    public class CommentController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<CommentDto>>> Get([FromRoute] GetAuthorCommentsQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<CommentDto>>> Get([FromRoute] GetBookCommentsQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAuthorCommentCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookCommentCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
