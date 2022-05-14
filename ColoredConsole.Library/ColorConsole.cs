using Console = System.Console;

namespace ColoredConsole.Library;
public static class ColorConsole
{
    public static string Prompt(string question)
    {
        var input = "";
        do
        {
            Console.Write(question + " ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }
    public static void WriteLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void Write(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
