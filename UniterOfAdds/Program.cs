//Answer to challenge question: since the method returns dynamic and both parameters are dynamic it is 100%
//possible to enter in different types that may either throw an error or return an unexpected result
//For example: providing two DateTime objects to the method throws an error

var a = Add(1, 2);
Console.WriteLine($"Ints: {a}");
var b = Add(3.14, 3.14);
Console.WriteLine($"Doubles: {b}");
var c = Add("Hello", "World");
Console.WriteLine($"Strings: {c}");
var d = Add(DateTime.Now, TimeSpan.FromMinutes(420));
Console.WriteLine($"DateTimes: {d}");


static dynamic Add(dynamic a, dynamic b) => a + b;