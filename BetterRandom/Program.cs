using BetterRandom;

Console.Title = "Better Random";

var rng = new Random();
Console.WriteLine($"Random double between 0 and 10 is {rng.NextDouble(10)}");
Console.WriteLine($"Random string from list of strings {{ one, two, three }} : {rng.NextString("one","two","three")}");
Console.WriteLine($"Coin flip result is {rng.CoinFlip()}");

Console.WriteLine("Answer to challenge question: ");
Console.WriteLine("It is much easier to work with extension methods than creating a derived class.");
Console.WriteLine("Extension methods mean we don't need to start using a completely different type. Just to get the functionality of a couple of methods");
