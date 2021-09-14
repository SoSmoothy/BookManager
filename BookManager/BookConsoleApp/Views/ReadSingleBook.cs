using System;
using BookConsoleApp.Framework;

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
                BookTitle = "Chưa có tiêu đề",
                Description = "Không có mô tả",
                Edition = 0,
                IdBook = 0,
                Publisher = "Chưa có nhà xuất bản sách",
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
                ViewHelp.WriteLine("Không tìm thấy sách!", ConsoleColor.Red);
                return;
            }
            
            ViewHelp.WriteLine("Thông tin chi tiết của sách: ", ConsoleColor.Green);
            
            Console.WriteLine($"Tiêu đề sách: {_model.BookTitle}");
            Console.WriteLine($"Mã số định danh: {_model.IdBook}");
            Console.WriteLine($"Nhà xuất bản: {_model.Publisher}");
            Console.WriteLine($"Năm xuất bản: {_model.YearRealease}");
            Console.WriteLine($"Tái bản: {_model.Edition}");
        }
        
        public void RenderToFile(string path)
        {
            ViewHelp.WriteLine($"Saving data to file '{path}'");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(_model);
            System.IO.File.WriteAllText(path, json);
            ViewHelp.WriteLine("Done!");
        }
    }
}