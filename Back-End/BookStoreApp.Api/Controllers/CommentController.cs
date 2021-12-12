using BookStoreApp.Application.Comments.Commands;
using BookStoreApp.Application.Comments.CommentDTOs;
using BookStoreApp.Application.Comments.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Api.Controllers
{
    public class CommentController : BaseController
    {
        [HttpGet("{EntityID}")]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetAuthorComments(Guid entityId, int pageNumber, int pageSize)
        {
            return await Mediator.Send(new GetCommentsQuery {EntityId = entityId, PageNumber = pageNumber, PageSize = pageSize });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCommentCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
