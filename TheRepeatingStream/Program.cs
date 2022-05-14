Console.WriteLine("Press any key when you see matching numbers in the array");
Thread.Sleep(1000);

var recents = new RecentNumbers();
var thread = new Thread(recents.GenerateRandoms);
thread.Start();
while (true)
{
    Console.ReadKey();
    Console.WriteLine(recents.RecentInts[0] == recents.RecentInts[1]
        ? "You correctly identified the repeat!"
        : "This was not a repeat");
}

public class RecentNumbers
{
    public int[] RecentInts
    {
        get
        {
            lock(_recentInts)
                return _recentInts;
        }
    }

    private readonly int[] _recentInts = new int[2];
    private readonly Random _rng = new();
    public void GenerateRandoms()
    {
        while (true)
        {
            lock (_recentInts)
            {
                _recentInts[0] = _recentInts[1];
                _recentInts[1] = _rng.Next(0,9);
                Console.WriteLine($"{_recentInts[0]},{_recentInts[1]}");
            }
            Thread.Sleep(1000);
        }
    }
}