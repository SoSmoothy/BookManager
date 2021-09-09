using System;
using BookConsoleApp.Framework;

namespace BookConsoleApp.Views
{
    using Models;
    public class BookUpdateView
    {
        protected Book Model;

        public BookUpdateView(Book model)
        {
            Model = model;
        }

        public void Render()
        {
            ViewHelp.WriteLine("Update Book Infomation: ", ConsoleColor.Green);

            var title = ViewHelp.InputString("Title: ", Model.BookTitle);
            var id = ViewHelp.InputInt("ID: ", Model.IdBook);
            var publisher = ViewHelp.InputString("Nhà Xuất Bản: ", Model.Publisher);
            var yearRelease = ViewHelp.InputInt("Năm Xuất Bản: ", Model.YearRealease);
            var edition = ViewHelp.InputInt("Tái Bản: ", Model.Edition);
            var description = ViewHelp.InputString("Mô tả: ", Model.Description);
        }
    }
}