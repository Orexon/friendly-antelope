using BookStoreApp.Core.ValueObjects;
using System;

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
        
        public Book(Guid id,string name, Guid authorId, Category category, string language, PublicationDate publicationDate, string coverPicture)
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

        //Update book picture.
        //Update book.
    }
}