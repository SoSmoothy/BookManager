using System;
using System.Text;
using BookConsoleApp.Controllers;

namespace BookConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            BookController bookController = new BookController();

            while (true)
            {
                Console.Write("Request> ");
                string request = Console.ReadLine();

                switch (request)
                {
                    case "single":
                        bookController.Single();
                        break;
                    case "create":
                        bookController.Create();
                        break;
                    default:
                        Console.WriteLine("Error 404");
                        break;
                }
            }
        }
    }
}