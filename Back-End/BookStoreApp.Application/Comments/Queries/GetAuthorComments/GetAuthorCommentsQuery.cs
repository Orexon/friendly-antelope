using AutoMapper;
using BookStoreApp.Application.Comments.CommentDTOs;
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

namespace BookStoreApp.Application.Comments.Queries.GetAuthorComments
{
    public class GetAuthorCommentsQuery : IRequest<List<CommentDto>>
    {
        public Guid AuthorId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }

    public class GetAuthorCommentsQueryHandler : IRequestHandler<GetAuthorCommentsQuery, List<CommentDto>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorCommentsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> Handle(GetAuthorCommentsQuery request, CancellationToken cancellationToken)
        {
            Author author = await _context.Authors.FindAsync(request.AuthorId);
            if (author == null)
            {
                throw new NotFoundException(nameof(Book), request.AuthorId);
            }

            return author.Comments
                            .OrderBy(x => x.PostDate)
                            .Skip((request.PageNumber - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .Select(c => new CommentDto { CommentContent = c.CommentContent, PostDate = c.PostDate })
                            .ToList();
        }
    }
}
