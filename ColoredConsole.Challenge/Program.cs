using ColoredConsole.Library; //Whoops naming the projects with a similar name caused some ambiguity

var name = ColorConsole.Prompt("What is your name?"); 
ColorConsole.WriteLine($"Hello {name}",ConsoleColor.Green);
