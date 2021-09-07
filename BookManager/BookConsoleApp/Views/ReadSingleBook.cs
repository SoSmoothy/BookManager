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
            if (_model == null)
            {
                WriteLine("No Book Found", ConsoleColor.Red);
                return;
            }
            
            WriteLine("Book Detail Info: ", ConsoleColor.Green);
            
            Console.WriteLine($"Title: {_model.BookTitle}");
            Console.WriteLine($"ID: {_model.IdBook}");
            Console.WriteLine($"Publisher: {_model.Publisher}");
            Console.WriteLine($"Year Release: {_model.YearRealease}");
            Console.WriteLine($"Edition: {_model.Edition}");
        }
        
        /// <summary>
        /// In ra màn hình với màu
        /// </summary>
        /// <param name="message">Chuỗi cần xuất ra màn hình</param>
        /// <param name="color">Màu</param>
        protected void WriteLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}