﻿using BookStoreApp.Application.Common.Interfaces;
using BookStoreApp.Core.Entity;
using BookStoreApp.Core.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStoreApp.Application.Books.Commands
{
    public class CreateBookCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }
        public string Language { get; set; }
        public string About { get; set; }
        public PublicationDate PublicationDate { get; set; }
        public string CoverPicture { get; set; }
    }

    public class CreateAuthorCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IAppDbContext _context;

        public CreateAuthorCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Book book = new(request.Id, request.Name,request.Author, request.Category, request.About, request.Language, request.PublicationDate, request.CoverPicture);

            _context.Books.Add(book);

            await _context.SaveChangesAsync(cancellationToken);

            return book.Id;
        }
    }
}