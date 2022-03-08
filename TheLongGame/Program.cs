Console.Title = "The Long Game";

Console.Write("Hello, please enter your name: ");

var name = Console.ReadLine();
while(string.IsNullOrWhiteSpace(name))
{
    Console.WriteLine("Please enter a non-empty name.");
    Console.Write("Name: ");
    name = Console.ReadLine();
}

Console.WriteLine($"Welcome, {name}.");
var save = LoadData(name);
var score = save.Score;
while(true)
{
    Console.Clear();
    Console.WriteLine($"{name} : {score}");
    Console.WriteLine("Press Enter to quit. Otherwise any key to increase score.");
    var key = Console.ReadKey(false);
    if (key.Key == ConsoleKey.Enter)
        break;

    score++;
}
save = new Save(name, score);
SaveData(save);
Console.WriteLine($"{save.Name}'s final score is {save.Score}");




void SaveData(Save saveData)
{
    List<string> scores = File.ReadAllLines("SaveData.txt").ToList<string>();
    for(var i = 0; i < scores.Count; i++)
    {
        var s = scores[i].Split(',');
        if(s[0] == saveData.Name)
        {
            scores[i] = $"{saveData.Name},{saveData.Score}";
            return;
        }
    }
    scores.Add($"{saveData.Name},{saveData.Score}");
    File.WriteAllLines("SaveData.txt",scores);
}

Save LoadData(string name)
{
    if (!File.Exists("SaveData.txt"))
    {
        File.Create("SaveData.txt");
        return new Save(name, 0);
    }

    var scores = File.ReadAllLines("SaveData.txt");
    for (var i = 0; i < scores.Length; i++)
    {
        var s = scores[i].Split(',');
        if (s[0] == name)
        {
            return new Save(s[0],Convert.ToInt32(s[1]));
        }
    }
    return new Save(name, 0);
}

public record Save(string Name, int Score);