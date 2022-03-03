using ExceptisGame;

Console.Title = "Cookie Exception";

var rng = new Random();
var badCookie = rng.Next(10);

try
{
    var guessList = new List<int>();
    var turnNumber = 0;
    while (true)
    {
        var playerTurn = (turnNumber % 2) + 1;
        Console.Write($"Player {playerTurn}, enter a value between 0 and 9: ");
        var input = Console.ReadLine();
        if (!ValidateInput(input!))
            continue;

        var guess = Convert.ToInt32(input);
        if (!guessList.Contains(guess))
        {
            turnNumber++;

            guessList.Add(guess);

            if (guess == badCookie)
                throw new SuccessException($"Player {playerTurn} has succeeded.");
        } else
        {
            DisplayInvalid("That number has already been guessed");
        }
    }
}
catch(SuccessException e)
{
    Console.Clear();
    var colors = Enum.GetValues<ConsoleColor>();
    foreach(var ch in e.Message)
    {
        Console.ForegroundColor = colors[rng.Next(colors.Length)];
        Console.Write(ch);
    }
    Console.ForegroundColor = ConsoleColor.White;
}
bool ValidateInput(string input)
{
    if(Int32.TryParse(input, out var i))
        return i >= 0 && i <= 9;
    DisplayInvalid("Invalid input");
    return false;
}

void DisplayInvalid(string input)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(input);
    Console.ForegroundColor = ConsoleColor.White;
}

//Answer to challenge question 1: I did make a custom exception for this because none of the built in exception types made sense for this use case
//Answer to challenge question 2: If the requirements did not demand an exception, I would not have used one for this purpose because an exception
//for completing an objective does not make a whole lot of sense