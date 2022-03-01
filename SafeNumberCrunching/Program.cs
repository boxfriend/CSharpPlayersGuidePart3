Console.Title = "Safe Number Crunching";

var i = GetInt();
Console.WriteLine($"Hooray, {i} is a valid integer!");
var d = GetDouble();
Console.WriteLine($"Hooray, {d} is a valid double!");
var b = GetBool();
Console.WriteLine($"Hooray, {b} is a valid boolean!");

int GetInt()
{
    while(true)
    {
        Console.Write("Please enter a valid integer: ");
        var input = Console.ReadLine();

        if(int.TryParse(input, out var result))
            return result;
    }
}

double GetDouble ()
{
    while (true)
    {
        Console.Write("Please enter a valid double: ");
        var input = Console.ReadLine();

        if (double.TryParse(input, out var result))
            return result;
    }
}

bool GetBool ()
{
    while (true)
    {
        Console.Write("Please enter a valid boolean: ");
        var input = Console.ReadLine();

        if (bool.TryParse(input, out var result))
            return result;
    }
}
