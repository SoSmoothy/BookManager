using System;
using BookConsoleApp.Framework;

namespace BookConsoleApp.Views
{
    using Utils;
    internal class CreateBook
    {
        public CreateBook(){}
        public void Render()
        {
            string title, publisher, description;
            int id, yearRelease, edition;
            
            ViewHelp.WriteLine("Thêm sách mới:", ConsoleColor.Green);
            
            title = ViewHelp.InputString("Tiêu đề sách: ");
            id = ViewHelp.InputInt("Mã định danh của sách: ");
            publisher = ViewHelp.InputString("Nhà xuất bản: ");
            yearRelease = ViewHelp.InputInt("Năm xuất bản: ");
            edition = ViewHelp.InputInt("Tái bản: ");
            description = ViewHelp.InputString("Mô tả: ");
        }
    }
}