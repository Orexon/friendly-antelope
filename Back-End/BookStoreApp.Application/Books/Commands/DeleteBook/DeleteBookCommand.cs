using BookStoreApp.Application.Common.Exceptions;
using BookStoreApp.Application.Common.Interfaces;
using BookStoreApp.Core.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreApp.Application.Authors.Commands.DeleteAuthor
{
    public class DeleteBookCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteBookCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            Book entity = await _context.Books.Where(x => x.Id == request.Id).SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            _context.Books.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
