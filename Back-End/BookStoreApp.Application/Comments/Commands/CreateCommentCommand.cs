using BookStoreApp.Application.Common.Exceptions;
using BookStoreApp.Application.Common.Interfaces;
using BookStoreApp.Core.Entity;
using BookStoreApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreApp.Application.Comments.Commands
{
    public class CreateCommentCommand : IRequest
    {
        public Guid EntityId { get; set; }
        public string CommentContent { get; set; }
    }

    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IAppDbContext _context;

        public CreateCommentCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            Author author = await _context.Authors.FindAsync(request.EntityId);
            Book book = await _context.Books.FindAsync(request.EntityId);

            if(author is null && book is null)
            {
                throw new NotFoundException(nameof(BaseEntity), request.EntityId);
            }
            if (author != null)
            {
                EntityComment comment = new(request.EntityId, DateTime.UtcNow, request.CommentContent);
                author.AddAuthorComment(comment);
                _context.Authors.Update(author);
            } else {
                EntityComment comment = new(request.EntityId, DateTime.UtcNow, request.CommentContent);
                book.AddBookComment(comment);
                _context.Books.Update(book);
            } 

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
