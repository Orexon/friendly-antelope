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

namespace BookStoreApp.Application.Books.Queries
{
    public class GetBooksQuery : IRequest<List<BookListDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 8;
    }

    public class GetAuthorsQueryHandler : IRequestHandler<GetBooksQuery, List<BookListDto>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookListDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books.OrderByDescending(a => a.Name)
                                        .AsNoTracking()
                                        .Skip((request.PageNumber - 1) * request.PageSize)
                                        .Take(request.PageSize)
                                        .ProjectTo<BookListDto>(_mapper.ConfigurationProvider)
                                        .ToListAsync(cancellationToken);
        }
    }
}
