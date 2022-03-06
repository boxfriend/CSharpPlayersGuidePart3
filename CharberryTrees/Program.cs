CharberryTree tree = new CharberryTree();
var notifier = new Notifier(tree);
var harvester = new Harvester(tree);

while(true)
    tree.MaybeGrow();

public class CharberryTree
{
    private Random _random = new Random();
    public bool Ripe { get; set; }

    public event Action? Ripened;

    public void MaybeGrow()
    {
        if(_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke();
        }
            
    }
}

public class Notifier
{
    public Notifier (CharberryTree tree) => tree.Ripened += () => Console.WriteLine("A charberry fruit has ripened!");
}

public class Harvester
{
    public int HarvestedFruit { get; private set; }
    private readonly CharberryTree _tree;
    public Harvester (CharberryTree tree)
    {
        _tree = tree;
        tree.Ripened += OnFruitRipened;
    }

    public void OnFruitRipened ()
    {
        HarvestedFruit++;
        Console.WriteLine($"Total harvested: {HarvestedFruit}");
        _tree.Ripe = false;
    }
}
