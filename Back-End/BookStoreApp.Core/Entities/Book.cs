using BookStoreApp.Core.ValueObjects;
using System;
using System.Collections.Generic;

namespace BookStoreApp.Core.Entity
{
    public class Book : BaseEntity
    {
        public string Name { get; private set; }
        public Guid AuthorId { get; private set; }
        public Category Category { get; private set; }
        public string Language { get; private set; } 
        public PublicationDate PublicationDate { get; private set; } 
        public string CoverPicture { get; private set; } //Change to appropriate Data type byte[]/string/File etc..

        private readonly List<Comment> _bookComments = new();
        public IReadOnlyCollection<Comment> BookComments => _bookComments.AsReadOnly();

        private Book(Guid id,string name, Guid authorId, Category category, string language, PublicationDate publicationDate, string coverPicture, List<Comment> bookComments)
            : this(id,name,authorId,category,language,publicationDate,coverPicture)
        {
            _bookComments = bookComments;
        }

        internal Book(Guid id, string name, Guid authorId, Category category, string language, PublicationDate publicationDate, string coverPicture)
        {
            //Guards & Exceptions
            Id = id;
            Name = name;
            AuthorId = authorId;
            Category = category;
            Language = language;
            PublicationDate = publicationDate;
            CoverPicture = coverPicture;
        }

        public void AddBookComment(Comment comment)
        {
            _bookComments.Add(comment);
        }

        public void AddBookComments(IEnumerable<Comment> comments)
        {
            foreach (var comment in comments)
            {
                AddBookComment(comment);
            }
        }

        //Update book picture.
        //Update book.
    }
}