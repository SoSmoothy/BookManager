using System;

namespace BookConsoleApp.Views
{
    using BookConsoleApp.Models;
    
    public class ReadSingleBook
    {
        private Book _model;

        public ReadSingleBook()
        {
            _model = new Book
            {
                BookTitle = "Unknown Title",
                Description = "Unknown Description",
                Edition = 0,
                IdBook = 0,
                Publisher = "Unknown Publisher",
                YearRealease = 1999
            };
        }

        public ReadSingleBook(Book book)
        {
            _model = book;
        }

        public void Read()
        {
            Console.Clear();
            Console.WriteLine(_model);
        }
    }
}