using BookStoreApp.Core.ValueObjects;
using System;
using System.Collections.Generic;

namespace BookStoreApp.Core.Entity
{
    public class Book : BaseEntity
    {
        public string Name { get; private set; }
        public Author Author { get; private set; }
        public Category Category { get; private set; }
        public string Language { get; private set; }
        public string About { get; private set; }
        public PublicationDate PublicationDate { get; private set; } 
        public string CoverPicture { get; private set; } //Change to appropriate Data type byte[]/string/File etc..

        private readonly List<Comment> _bookComments = new();
        public IReadOnlyCollection<Comment> BookComments => _bookComments.AsReadOnly();

        private Book(string name, Author author, Category category, string language, string about,PublicationDate publicationDate, string coverPicture, List<Comment> bookComments)
            : this(name,author,category,language, about,publicationDate, coverPicture)
        {
            _bookComments = bookComments;
        }

        public Book() //for EF
        {

        }
        public Book(string name, Author author, Category category, string language,string about, PublicationDate publicationDate, string coverPicture)
        {
            //Guards & Exceptions
            Name = name;
            Author = author;
            Category = category;
            Language = language;
            About = about;
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

        public void UpdateBook(string name, Author author, Category category, string language, string about, PublicationDate publicationDate)
        {
            //Guards or Exceptions
            Name = name;
            Author = author;
            Category =  category;
            Language = language;
            About = about;
            PublicationDate = publicationDate;
        }

        public void UpdateBookPicture(string newPicture)
        {
            //Guards or Exceptions
            CoverPicture = newPicture;
        }
    }
}