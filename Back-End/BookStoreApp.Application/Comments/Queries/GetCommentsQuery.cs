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

namespace BookStoreApp.Application.Comments.Queries
{
    public class GetCommentsQuery : IRequest<List<CommentDto>>
    {
        public Guid EntityId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }

    public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, List<CommentDto>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetCommentsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            Author author = await _context.Authors.FindAsync(request.EntityId);
            Book book = await _context.Books.FindAsync(request.EntityId);

            if (author is null && book is null)
            {
                throw new NotFoundException(nameof(BaseEntity), request.EntityId);
            }
            if (author != null)
            {
                return author.Comments.OrderBy(x => x.PostDate)
                                      .Skip((request.PageNumber - 1) * request.PageSize)
                                      .Take(request.PageSize)
                                      .Select(c => new CommentDto { CommentContent = c.CommentContent, PostDate = c.PostDate })
                                      .ToList();
            }
            else
            {
                return book.Comments.OrderBy(x => x.PostDate)
                                      .Skip((request.PageNumber - 1) * request.PageSize)
                                      .Take(request.PageSize)
                                      .Select(c => new CommentDto { CommentContent = c.CommentContent, PostDate = c.PostDate })
                                      .ToList();
            }
        }
    }
}
