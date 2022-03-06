Console.Title = "The Sieve";

var value = 0;
while(true)
{
    Console.Clear();
    Console.WriteLine("Which of the following would you like?");
    Console.WriteLine("1 - Even Checking Sieve");
    Console.WriteLine("2 - Positive Checking Sieve");
    Console.WriteLine("3 - Multiple of Ten Checking Sieve");
    Console.Write("\nEnter a number from 1 to 3 indicating which option you would like: ");
    var input = Console.ReadLine();
    if (int.TryParse(input, out value))
    {
        break;
    }
}
var sieve = GetSieveFromInput(value);
while(true)
{
    Console.Write("Enter a number to check it with the sieve: ");
    if(int.TryParse(Console.ReadLine(), out value))
    {
        var adjective = sieve.IsGood(value) ? "good" : "bad";
        Console.WriteLine($"{value} is {adjective}");
    }
}


Sieve GetSieveFromInput(int input)
{
    return input switch
    {
        1 => Sieve.EvenChecker(),
        2 => Sieve.PositiveChecker(),
        3 => Sieve.TensChecker(),
        _ => throw new NotImplementedException("Not a valid selection. Now you have to restart")
    };
}

class Sieve
{
    private readonly Func<int, bool> _funk;
    public Sieve (Func<int, bool> goodChecker) => _funk = goodChecker;
    public bool IsGood (int number) => _funk.Invoke(number);

    public static Sieve EvenChecker() => new (x => x % 2 == 0);
    public static Sieve PositiveChecker () => new(x => x >= 0);
    public static Sieve TensChecker () => new(x => x % 10 == 0);
}


//Answer to challenge question: This could easily have been solved using inheritance or even an interface where each class checks a specific condition
//That approach is much messier though and can potentially lead to complicated inheritance hierarchies and managing multiple different types
//This approach using delegates is much simpler to implement because we can easily change its behavior with a new instance and different delegate
//rather than creating a whole new type just to change one behavior

//WHOOPS, i was already using lambdas for the ctors so The Lamda Sieve challenge was already completed
//Answer to challenge questions: the code is shorter and easier to write, for those that don't already understand the syntax for a lambda it is harder to read
//I already knew about lambdas when completing this challenge previously and somehow didn't notice that they weren't yet brought up in the delegates chapter
//so i ended up using them to make the code short. this was technically against my personal challenge of not using anything the book hasn't introduced yet,
//but they are just so easy/intuitive to use for things like this that it slipped my mind completely