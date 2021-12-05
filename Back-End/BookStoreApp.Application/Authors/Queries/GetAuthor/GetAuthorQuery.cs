using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStoreApp.Application.Authors.AuthorDTOs;
using BookStoreApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreApp.Application.Authors.Queries.GetAuthor
{
    public class GetAuthorQuery : IRequest<AuthorDto>
    {
        public Guid Id { get; set; }
    }

    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, AuthorDto>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            return await _context.Authors.Include(a => a.Books).Where(a => a.Id == request.Id).AsNoTracking().ProjectTo<AuthorDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
