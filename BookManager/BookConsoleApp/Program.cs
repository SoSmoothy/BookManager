using System;
using System.Text;
using BookConsoleApp.Framework;

namespace BookConsoleApp
{
    using Controllers;
    using DataServices;
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            SimpleDataAccess context = new SimpleDataAccess();
            BookController bookController = new BookController(context);
            
            Router r = Router.Instance;
            r.Register("about", About);
            r.Register("help", Help);
            r.Register(
                route: "create",
                action: r => bookController.Create(),
                help: "[create]\r\nTạo sách mới");
            r.Register(
                route: "update",
                action: p => bookController.Update(p["id"].ToInt()),
                help: "[update ? id = <value>]\r\nTìm và sửa sách");
            r.Register(
                route: "read",
                action: p => bookController.Single(p["id"].ToInt()),
                help: "[read ? id = <value>]\r\nĐọc sách dựa vào ID của sách");
            r.Register(
                route: "list",
                action: p => bookController.List(),
                help: "[list]\r\nXem tất cả những sách hiện đang có");
            
            r.Register(
                route: "list file",
                action: p => bookController.List(p["path"]),
                help: "[list file ? path = <value>]\r\nHiển thị tất cả sách");
            r.Register(
                route: "read file",
                action: p => bookController.Single(p["id"].ToInt(), p["path"]),
                help: "[read file ? id = <value> & path = <value>]");

            while (true)
            {
                ViewHelp.Write("# Request >> ", ConsoleColor.Green);
                string request = Console.ReadLine();

                Router.Instance.Forward(request);
                Console.WriteLine();
            }
        }

        private static void About(Parameter parameter)
        {
            ViewHelp.WriteLine("Book Manager ver 1", ConsoleColor.Green);
            ViewHelp.WriteLine("By PAD2k2", ConsoleColor.Cyan);
        }

        private static void Help(Parameter parameter)
        {
            if (parameter == null)
            {
                ViewHelp.WriteLine("Commands: ", ConsoleColor.Green);
                ViewHelp.WriteLine(Router.Instance.GetRoutes(), ConsoleColor.Green);
                ViewHelp.WriteLine("type: help ? cmd=<command>");
                return;
            }

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            var cmd = parameter["cmd"].ToLower();
            ViewHelp.WriteLine(Router.Instance.GetHelp(cmd));
        }
    }
}