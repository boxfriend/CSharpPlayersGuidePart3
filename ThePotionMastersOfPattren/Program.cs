Console.Title = "The Potion Masters of Pattren";

var potion = PotionType.Water;

Console.WriteLine("You are given a bottle of water and must create a potion from it.");
Console.WriteLine("Press any key to begin brewing. . .");
Console.ReadKey();

while(potion != PotionType.Ruined)
{
    DisplayMenu(potion);
    var ingredient = GetInput();
    potion = AddIngredient(potion, ingredient);

    if (ingredient == IngredientType.None)
        break;
}

Console.WriteLine($"You hold in your hands a {potion} potion.");
Console.WriteLine("I guess we are done here.");

PotionType AddIngredient(PotionType potion, IngredientType ingredient)
{
    return (potion, ingredient) switch
    {
        (PotionType.Water, IngredientType.Stardust) => PotionType.Elixir,
        (PotionType.Elixir, IngredientType.SnakeVenom) => PotionType.Poison,
        (PotionType.Elixir, IngredientType.DragonBreath) => PotionType.Flying,
        (PotionType.Elixir, IngredientType.ShadowGlass) => PotionType.Invisibility,
        (PotionType.Elixir, IngredientType.EyeshineGem) => PotionType.NightSight,
        (PotionType.NightSight, IngredientType.ShadowGlass) 
        or (PotionType.Invisibility, IngredientType.EyeshineGem) => PotionType.CloudyBrew,
        (PotionType.CloudyBrew, IngredientType.Stardust) => PotionType.Wraith,
        (_, IngredientType.None) => potion,
        _ => PotionType.Ruined
    };
}

IngredientType GetInput()
{
    var input = "";
    while(!int.TryParse(input, out var r) && !Enum.IsDefined(typeof(IngredientType),r))
    {
        Console.Write("Enter a number to make a selection or nothing to complete the potion: ");
        input = Console.ReadLine();
    }
    return (IngredientType)Convert.ToInt32(input);
}

void DisplayMenu(PotionType potion)
{
    Console.Clear();
    Console.WriteLine($"You currently have a {potion} potion.");
    var i = 1;
    foreach(var thing in Enum.GetValues(typeof(IngredientType)))
    {
        Console.WriteLine($"{i++}: {thing}");
    }
    Console.WriteLine("Which ingredient would you like to add?");
}
enum PotionType
{
    Water,
    Elixir,
    Poison,
    Flying,
    Invisibility,
    NightSight,
    CloudyBrew,
    Wraith,
    Ruined
}

enum IngredientType
{
    Stardust = 1,
    SnakeVenom,
    DragonBreath,
    ShadowGlass,
    EyeshineGem,
    None
}