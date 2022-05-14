using System.Diagnostics;
using System.Text;

while (true)
{
    var input = "";
    do
    {
        Console.Write("Please enter a valid word: ");
        input = Console.ReadLine();
    } while (!IsValidInput(input!));

    var stopwatch = new Stopwatch();
    Console.WriteLine("Calculating attempts to recreate the word using a random number generator. . .");
    var attempts = await RandomlyRecreateAsync(input!);
    Console.WriteLine($"It took {attempts} in {stopwatch.Elapsed}");
}

Task<int> RandomlyRecreateAsync(string word)
{
    return Task.Run(() => RandomlyRecreate(word));
}

int RandomlyRecreate(string word)
{
    var a = (int) 'a';
    var z = (int) 'z';
    word = word.ToLower();

    var builder = new StringBuilder();
    var rng = new Random();
    var attempts = 0;
    while (builder.ToString() != word)
    {
        builder.Clear();
        for (int i = 0; i < word.Length; i++)
        {
            var randomChar = (char) rng.Next(a,z+1);
            builder.Append(randomChar);
        }
        attempts++;
    }
    return attempts;
}

bool IsValidInput(string input)
{
    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Input cannot be empty.");
        return false;
    }

    foreach (var c in input)
    {
        if (!char.IsLetter(c))
        {
            Console.WriteLine("Input must only contain letters.");
            return false;
        }
    }
    return true;
}