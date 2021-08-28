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
            bookController.Single();
        }
    }
}