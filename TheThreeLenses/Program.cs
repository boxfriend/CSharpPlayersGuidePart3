var input = new int[] {1,9,2,8,3,7,4,6,5};
var expectedOutput = new int[] {4, 8, 12, 16};

var proc = ProceduralGet(input);
var key = KeywordGet(input);
var method = MethodCallGet(input);

foreach (var i in proc)
{
    Console.Write(i + " ");
}
Console.WriteLine($"Passed check: {DoesPass(proc,expectedOutput)}");
foreach (var i in key)
{
    Console.Write(i + " ");
}
Console.WriteLine($"Passed check: {DoesPass(key, expectedOutput)}");
foreach (var i in method)
{
    Console.Write(i + " ");
}
Console.WriteLine($"Passed check: {DoesPass(method, expectedOutput)}");


IEnumerable<int> ProceduralGet(int[] input)
{
    var result = new List<int>();
    var copy = new int[input.Length];

    //copy array so we aren't modifying original
    input.CopyTo(copy, 0);
    Array.Sort(copy);

    foreach (int i in copy)
    {
        if(i % 2 == 0)
            result.Add(i*2);
    }
    return result;
}

IEnumerable<int> KeywordGet(int[] input)
{
    return from i in input
            where i % 2 == 0
            orderby i
            select i*2;
}

IEnumerable<int> MethodCallGet(int[] input)
{
    return input.Where(i => i % 2 == 0).OrderBy(i => i).Select(i => i * 2);
}

bool DoesPass(IEnumerable<int> input, int[] expected)
{
    var check = input.ToArray();
    for (var i = 0; i < check.Length; i++)
    {
        if (check[i] != expected[i])
            return false;
    }
    return true;
}