using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStoreApp.Application.Books.BooksDTOs;
using BookStoreApp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreApp.Application.Books.Queries.GetBook
{
    public class GetBookQuery : IRequest<BookDto>
    {
        public Guid Id { get; set; }
    }

    public class GetAuthorQueryHandler : IRequestHandler<GetBookQuery, BookDto>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books.Where(a => a.Id == request.Id).AsNoTracking().ProjectTo<BookDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
