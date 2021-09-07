using System;

namespace BookConsoleApp.Utils
{
    public class Print
    {
        public static void SendNewLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        
        public static void Send(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}