using BookStoreApp.Application.DTOs.AuthorDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreApp.Application.Authors.Queries.GetAuthors
{
    public class GetAuthorsQuery : IRequest<IEnumerable<AuthorDto>>
    {
    }


    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, IEnumerable<AuthorDto>>
    {
        public Task<IEnumerable<AuthorDto>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }




    }
}
