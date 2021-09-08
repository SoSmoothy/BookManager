using System;

namespace BookConsoleApp.Utils
{
    public class Print
    {
        public static void SendNewLine(string message, ConsoleColor color, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            if (resetColor)
            {
                Console.ResetColor();
            }
        }
        
        public static void Send(string message, ConsoleColor color, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            if (resetColor)
            {
                Console.ResetColor();
            }
        }
    }
}