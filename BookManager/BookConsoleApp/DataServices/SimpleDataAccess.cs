using System.Collections.Generic;

namespace BookConsoleApp.DataServices
{
    using Models;
    public class SimpleDataAccess
    {
        public List<Book> Books { get; set; }

        public void Load()
        {
            Books = new List<Book>
            {
                new Book {IdBook = 1, BookTitle = "A New Book 1"},
                new Book {IdBook = 2, BookTitle = "A New Book 2"},
                new Book {IdBook = 3, BookTitle = "A New Book 3"},
                new Book {IdBook = 4, BookTitle = "A New Book 4"},
            };
        }
        
        public void SaveChanges(){}
    }
}