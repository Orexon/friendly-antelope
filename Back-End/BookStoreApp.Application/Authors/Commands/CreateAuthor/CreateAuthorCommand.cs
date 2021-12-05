using BookStoreApp.Application.Common.Interfaces;
using BookStoreApp.Core.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreApp.Application.Authors.Commands
{
    public class CreateAuthorCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AboutAuthor { get; set; }
        public string Picture { get; set; }
    }

    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Guid>
    {
        private readonly IAppDbContext _context;

        public CreateAuthorCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            Author author = new(request.FirstName, request.LastName,request.AboutAuthor,request.Picture);

            _context.Authors.Add(author);

            await _context.SaveChangesAsync(cancellationToken);

            return author.Id;
        }
    }
}
