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
            return await _context.Authors.AsNoTracking().ProjectTo<AuthorListDto>(_mapper.ConfigurationProvider).OrderBy(b => b.LastName).ToListAsync(cancellationToken);

            //return await _context.Authors.Select(a => new AuthorListDto { FirstName = a.FirstName, LastName = a.LastName, AboutAuthor = a.AboutAuthor, Picture = a.Picture }).ToListAsync(cancellationToken);
            //_context.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();  
        }
    }
}
