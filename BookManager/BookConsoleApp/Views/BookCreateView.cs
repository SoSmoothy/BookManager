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
            
            ViewHelp.WriteLine("Create New Book:", ConsoleColor.Green);
            
            title = ViewHelp.InputString("Title: ");
            id = ViewHelp.InputInt("ID: ");
            publisher = ViewHelp.InputString("Nhà Xuất Bản: ");
            yearRelease = ViewHelp.InputInt("Năm xuất bản: ");
            edition = ViewHelp.InputInt("Tái bản: ");
            description = ViewHelp.InputString("Mô tả: ");
        }
    }
}