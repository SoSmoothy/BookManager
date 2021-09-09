using System;

namespace BookConsoleApp.Framework
{
    public class ViewHelp
    {
        public static void WriteLine(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            if (resetColor)
            {
                Console.ResetColor();
            }
        }

        public static void Write(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            if (resetColor)
            {
                Console.ResetColor();
            }
        }

        public static bool InputBool(string label, ConsoleColor labelColor = ConsoleColor.Magenta,
            ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label}  [y/n]: ", labelColor);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();
            bool @char = keyInfo.KeyChar == 'y' || keyInfo.KeyChar == 'Y' ? true : false;
            return @char;
        }
        
        public static int InputInt(string label, ConsoleColor color = ConsoleColor.Magenta,
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

        public static int InputInt(string label, int oldValue, ConsoleColor color = ConsoleColor.Magenta,
            ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label}: ", color);
            WriteLine($"{oldValue}", ConsoleColor.Yellow);
            Write("New value >> ", ConsoleColor.Green);
            Console.ForegroundColor = valueColor;
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str.Trim())) return oldValue;
            if (str.ToInt(out int i)) return i;
            return oldValue;
        }
        
        public static string InputString(string label, ConsoleColor color = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label}", color, false);
            Console.ForegroundColor = valueColor;
            string value = Console.ReadLine();
            Console.ResetColor();
            return value;
        }

        public static string InputString(string label, string oldValue, ConsoleColor color = ConsoleColor.Magenta,
            ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label}: ", color);
            WriteLine(oldValue, ConsoleColor.Yellow);
            Write("New Value >> ", ConsoleColor.Green);
            Console.ForegroundColor = valueColor;
            string newValue = Console.ReadLine();
            return string.IsNullOrEmpty(newValue.Trim()) ? oldValue : newValue;
        }
    }
}