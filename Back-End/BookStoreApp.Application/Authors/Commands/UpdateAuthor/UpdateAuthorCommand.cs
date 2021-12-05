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

namespace BookStoreApp.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AboutAuthor { get; set; }
        public string Picture { get; set; }
    }

    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateAuthorCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            Author author = await _context.Authors.FindAsync(request.Id);  

            if (author == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }

            author.UpdateAuthor(request.FirstName, request.LastName, request.AboutAuthor);
            author.UpdateAuthorPicture(request.Picture);

            _context.Authors.Update(author);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }


}
