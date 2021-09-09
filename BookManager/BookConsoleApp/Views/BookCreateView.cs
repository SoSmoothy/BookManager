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
            title = InputString("Title: ");
            id = InputInt("ID: ");
            publisher = InputString("Nhà Xuất Bản: ");
            yearRelease = InputInt("Năm xuất bản: ");
            edition = InputInt("Tái bản: ");
            description = InputString("Mô tả: ");
        }
        
        /// <summary>
        /// In ra màn hình và tiếp nhận chuỗi kí tự người dùng nhập rồi chuyển sang số nguyên
        /// </summary>
        /// <param name="label">thông báo</param>
        /// <param name="color">màu thông báo</param>
        /// <param name="valueColor">màu người dùng nhập</param>
        /// <returns></returns>
        private int InputInt(string label, ConsoleColor color = ConsoleColor.Magenta,
            ConsoleColor valueColor = ConsoleColor.White)
        {
            while (true)
            {
                string str = InputString(label, color, valueColor);
                var result = int.TryParse(str, out int i);
                if (result)
                {
                    return i;
                }
            }
        }
        
        /// <summary>
        /// In ra thông báo và nhận chuỗi do người dùng nhập vào
        /// </summary>
        /// <param name="label">thông báo</param>
        /// <param name="color">màu</param>
        /// <param name="valueColor">màu chữ người nhập</param>
        /// <returns></returns>
        private string InputString(string label, ConsoleColor color = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Print.Send($"{label}", color, false);
            Console.ForegroundColor = valueColor;
            string value = Console.ReadLine();
            Console.ResetColor();
            return value;
        }
    }
}