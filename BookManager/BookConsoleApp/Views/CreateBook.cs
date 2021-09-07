using System;

namespace BookConsoleApp.Views
{
    using Utils;
    internal class CreateBook
    {
        public CreateBook(){}
        
        /// <summary>
        /// Yều Cầu Người Dùng Nhập Thông Tin Sách Muốn Thêm
        /// </summary>
        public void Render()
        {
            string title, publisher, description;
            int id, yearRelease, edition;
            
            Print.SendNewLine("Create New Book:", ConsoleColor.Green);
            Print.Send("Title: ", ConsoleColor.Magenta);
            title = Console.ReadLine();
            
            Print.Send("ID: ", ConsoleColor.Magenta);
            id = Convert.ToInt32(Console.ReadLine());
            
            Print.Send("Nhà Xuất Bản: ", ConsoleColor.Magenta);
            publisher = Console.ReadLine();
            
            Print.Send("Năm xuất bản: ", ConsoleColor.Magenta);
            yearRelease = Convert.ToInt32(Console.ReadLine());
            
            Print.Send("Tái bản: ", ConsoleColor.Magenta);
            edition = Convert.ToInt32(Console.ReadLine());
            
            Print.Send("Mô tả: ", ConsoleColor.Magenta);
            description = Console.ReadLine();
        }
    }
}