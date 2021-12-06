using BookStoreApp.Application.Common.Exceptions;
using BookStoreApp.Application.Common.Interfaces;
using BookStoreApp.Core.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreApp.Application.Comments.Commands
{
    public class CreateAuthorCommentCommand : IRequest
    {
        public Guid Id { get; set; }

        public string CommentContent { get; set; }
    }

    public class CreateAuthorCommentCommandHandler : IRequestHandler<CreateAuthorCommentCommand>
    {
        private readonly IAppDbContext _context;

        public CreateAuthorCommentCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateAuthorCommentCommand request, CancellationToken cancellationToken)
        {
            Author author = await _context.Authors.FindAsync(request.Id);
            if (author == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }

            Comment comment = new(DateTime.UtcNow, request.CommentContent);

            author.AddAuthorComment(comment);
            _context.Authors.Update(author);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}