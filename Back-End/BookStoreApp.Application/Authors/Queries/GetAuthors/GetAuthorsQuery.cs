using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStoreApp.Application.Common.Interfaces;
using BookStoreApp.Application.DTOs.AuthorDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreApp.Application.Authors.Queries.GetAuthors
{
    public class GetAuthorsQuery : IRequest<List<AuthorListDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 8;
    }

    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, List<AuthorListDto>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<AuthorListDto>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Authors.OrderByDescending(a=>a.LastName)
                                         .Skip((request.PageNumber - 1) * request.PageSize)
                                         .Take(request.PageSize)
                                         .ProjectTo<AuthorListDto>(_mapper.ConfigurationProvider)
                                         .ToListAsync(cancellationToken);
        }
    }
}
