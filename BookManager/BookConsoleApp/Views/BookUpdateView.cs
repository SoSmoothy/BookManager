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
            ViewHelp.WriteLine("Cập nhật và thay đổi thông tin sách: ", ConsoleColor.Green);

            var title = ViewHelp.InputString("Tiêu đề của sách: ", Model.BookTitle);
            var id = ViewHelp.InputInt("Mã số định danh của sách: ", Model.IdBook);
            var publisher = ViewHelp.InputString("Nhà xuất Bản: ", Model.Publisher);
            var yearRelease = ViewHelp.InputInt("Năm xuất Bản: ", Model.YearRealease);
            var edition = ViewHelp.InputInt("Tái bản: ", Model.Edition);
            var description = ViewHelp.InputString("Mô tả: ", Model.Description);
        }
    }
}