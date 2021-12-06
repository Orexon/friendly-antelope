using AutoMapper;
using BookStoreApp.Application.Comments.CommentDTOs;
using BookStoreApp.Application.Common.Exceptions;
using BookStoreApp.Application.Common.Interfaces;
using BookStoreApp.Core.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreApp.Application.Comments.Queries.GetBookComments
{
    public class GetBookCommentsQuery : IRequest<List<CommentDto>>
    {
        public Guid BookId { get; set; }
    }

    public class GetBookCommentsQueryHandler : IRequestHandler<GetBookCommentsQuery, List<CommentDto>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetBookCommentsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> Handle(GetBookCommentsQuery request, CancellationToken cancellationToken)
        {
            Book book = await _context.Books.FindAsync(request.BookId);
            if (book == null)
            {
                throw new NotFoundException(nameof(Book), request.BookId);
            }

            return book.BookComments.OrderBy(x => x.PostDate).Select(c => new CommentDto { CommentContent = c.CommentContent, PostDate = c.PostDate }).ToList();

            //return book.BookComments.OrderBy(x => x.PostDate)
            //                        .Skip((request.PageNumber - 1) * request.PageSize)
            //                        .Take(request.PageSize)
            //                        .Select(c=> new CommentDto { CommentContent = c.CommentContent, PostDate = c.PostDate}).ToList();
        }
    }
}
