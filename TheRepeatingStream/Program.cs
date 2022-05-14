Console.WriteLine("Press any key when you see matching numbers in the list");
Thread.Sleep(1000);

var recents = new RecentNumbers();
var thread = new Thread(recents.GenerateRandoms);
thread.Start();
while (true)
{
    Console.ReadKey();
    Console.WriteLine(AnyDuplicates(recents.RecentInts)
        ? "The list contains a duplicate!"
        : "There are no duplicates here");
}

static bool AnyDuplicates(IReadOnlyList<int> list)
{
    for (var i = 0; i < list.Count-1; i++)
    {
        for (var j = i + 1; j < list.Count; j++)
        {
            if(list[j] == list[i])
                return true;
        }
    }
    return false;
}

public class RecentNumbers
{
    public List<int> RecentInts
    {
        get
        {
            lock(_recentInts)
                return _recentInts;
        }
    }

    private readonly List<int> _recentInts = new();
    private readonly Random _rng = new();
    public void GenerateRandoms()
    {
        while (true)
        {
            lock (_recentInts)
            {
                if(_recentInts.Count > 3)
                    _recentInts.RemoveAt(0);

                _recentInts.Add(_rng.Next(0,9));
                foreach(var item in _recentInts)
                    Console.Write(item + " ");
                Console.WriteLine();
            }
            Thread.Sleep(1000);
        }
    }
}