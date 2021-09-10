using System;
using System.Text;

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

            while (true)
            {
                Console.Write("Request> ");
                string request = Console.ReadLine();

                switch (request)
                {
                    case "single":
                        bookController.Single(1);
                        break;
                    case "create":
                        bookController.Create();
                        break;
                    case "update":
                        bookController.Update(1);
                        break;
                    case "list":
                        bookController.List();
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Error 404");
                        break;
                }
            }
        }
    }
}