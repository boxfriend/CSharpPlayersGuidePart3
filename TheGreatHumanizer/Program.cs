using Humanizer;

Console.WriteLine($"When is the feast? {DateTime.UtcNow.AddHours(30).Humanize()}");
Console.WriteLine($"When is the feast? {DateTime.UtcNow.AddHours(1).Humanize()}");
Console.WriteLine($"When is the feast? {DateTime.UtcNow.AddHours(42).Humanize()}");
Console.WriteLine($"When is the feast? {DateTime.UtcNow.AddHours(69).Humanize()}");
Console.WriteLine($"When is the feast? {DateTime.UtcNow.AddHours(420).Humanize()}");