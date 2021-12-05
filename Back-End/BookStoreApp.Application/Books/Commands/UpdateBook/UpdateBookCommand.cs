using BookStoreApp.Application.Common.Exceptions;
using BookStoreApp.Application.Common.Interfaces;
using BookStoreApp.Core.Entity;
using BookStoreApp.Core.ValueObjects;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreApp.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public Category Category { get; set; }
        public string Language { get; set; }
        public string About { get; set; }
        public PublicationDate PublicationDate { get; set; }
        public string CoverPicture { get; set; }
    }

    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateAuthorCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Book book = await _context.Books.FindAsync(request.Id);
            Author author = _context.Authors.Where(x => x.Id == request.AuthorId).FirstOrDefault();

            if (book == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            book.UpdateBook(request.Name, author, request.Category, request.Language, request.About, request.PublicationDate);
            book.UpdateBookPicture(request.CoverPicture);

            _context.Books.Update(book);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
