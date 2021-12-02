using BookStoreApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Core.Entity
{
    public class Author : BaseEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string AboutAuthor { get; private set; }
        public string Picture { get; private set; }//Change to appropriateData type byte[]/string/File etc..

        private readonly List<Book> _books = new();
        public IReadOnlyCollection<Book> Books => _books.AsReadOnly();
        // Using List<>.AsReadOnly() 
        // This will create a read only wrapper around the private list so is protected against "external updates".
        // It's much cheaper than .ToList() because it will not have to copy all items in a new collection. (Just one heap alloc for the wrapper instance)
        //https://msdn.microsoft.com/en-us/library/e78dcd75(v=vs.110).aspx 

        private readonly List<Comment> _comments = new();
        public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();


        private Author(Guid id, string firstName, string lastName, string aboutAuthor, string picture, List<Book> books, List<Comment> comments) 
            : this(id, firstName, lastName,aboutAuthor,picture)
        {
            _books = books;
            _comments = comments;
        }

        private Author() // For EF
        {
        }

        internal Author(Guid id, string firstName, string lastName, string aboutAuthor, string picture)
        {
            //Guards or exceptions.
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            AboutAuthor = aboutAuthor;
            Picture = picture;
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void AddBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                AddBook(book);
            }
        }

        public void AddAuthorComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public void AddAuthorComments(IEnumerable<Comment> comments)
        {
            foreach (var comment in comments)
            {
                AddAuthorComment(comment);
            }
        }

        //Update Author picture. 
        //Update author.
    }
}
