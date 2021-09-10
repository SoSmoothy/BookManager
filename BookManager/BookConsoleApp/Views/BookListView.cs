using System;
using BookConsoleApp.Framework;

namespace BookConsoleApp.Views
{
    using Models;
    internal class BookListView
    {
        protected Book[] Model;

        public BookListView(Book[] model)
        {
            Model = model;
        }

        public void Render()
        {
            if (Model.Length == 0)
            {
                ViewHelp.WriteLine("Không tìm thấy quyển sách nào cả!", ConsoleColor.Red);
                return;
            }
            ViewHelp.WriteLine("Danh sách các quyển sách!");

            foreach (Book book in Model)
            {
                ViewHelp.Write($"[{book.IdBook}] ", ConsoleColor.Yellow);
                ViewHelp.WriteLine($"{book.BookTitle}");
            }
        }
    }
}