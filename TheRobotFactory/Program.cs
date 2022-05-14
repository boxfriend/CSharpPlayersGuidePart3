using System.Dynamic;

var i = 1;
for (;;)
{
    dynamic robot = new ExpandoObject();
    robot.ID = i++;
    Console.WriteLine($"You are producing robot #{robot.ID}");
    GetName(robot);
    GetSize(robot);
    GetColor(robot);
    foreach (KeyValuePair<string, object> obj in robot)
    {
        Console.WriteLine($"{obj.Key}: {obj.Value}");
    }
    SeparateLoops();
}

void SeparateLoops()
{
    for (var i = 0; i < 50; i++)
        Console.Write("-");
    Console.WriteLine();
}

void GetName(dynamic robot)
{
    if (!GetBooleanInput("Do you want to name this robot?")) return;

    var name = "";
    while (string.IsNullOrWhiteSpace(name))
    {
        Console.Write("What is its name? ");
        name = Console.ReadLine();
    }
    robot.Name = name;
}

void GetSize(dynamic robot)
{
    if (!GetBooleanInput("Does this robot have a specific size?")) return;
    robot.Width = GetIntInput("What is its width?");
    robot.Height = GetIntInput("What is its height?");
}

void GetColor(dynamic robot)
{
    if (!GetBooleanInput("Does this robot have a specific color?")) return;
    var input = "";
    while(string.IsNullOrWhiteSpace(input))
    {
        Console.Write("What color? ");
        input = Console.ReadLine(); //i know i *should* validate this input but honestly i just want to finish this
    }
    robot.Color = input;
}

bool GetBooleanInput(string message)
{
    var input = "";
    do
    {
        Console.Write($@"{message} Y\N ");
        input = Console.ReadLine();
    } while (input.ToLower() is not ("y" or "n" or "yes" or "no"));

    return input.ToLower() is "y" or "yes";
}

int GetIntInput(string message)
{
    var input = "";
    do
    {
        Console.Write($@"{message} ");
        input = Console.ReadLine();
    } while (Convert.ToInt32(input) <= 0);
    return Convert.ToInt32(input);
}