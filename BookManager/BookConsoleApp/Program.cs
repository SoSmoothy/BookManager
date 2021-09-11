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
            
            Router.Instance.Register("about", About);
            Router.Instance.Register("help", Help);

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