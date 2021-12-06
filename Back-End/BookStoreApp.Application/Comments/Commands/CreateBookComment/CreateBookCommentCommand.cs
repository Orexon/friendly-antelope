using BookStoreApp.Application.Common.Exceptions;
using BookStoreApp.Application.Common.Interfaces;
using BookStoreApp.Core.Entity;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreApp.Application.Comments.Commands.CreateBookComment
{
    public class CreateBookCommentCommand : IRequest
    {
        public Guid Id { get; set; }

        public string CommentContent { get; set; }
    }

    public class CreateBookCommentCommandHandler : IRequestHandler<CreateBookCommentCommand>
    {
        private readonly IAppDbContext _context;

        public CreateBookCommentCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateBookCommentCommand request, CancellationToken cancellationToken)
        {
            Book book = await _context.Books.FindAsync(request.Id);
            if (book == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            Comment comment = new(DateTime.UtcNow, request.CommentContent);

            book.AddBookComment(comment);
            _context.Books.Update(book);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
