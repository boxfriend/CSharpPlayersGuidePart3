using IField;
using McDroid;
using IPig = IField.Pig;
using MPig = McDroid.Pig;

Console.Title = "The Feud";

//ha ha jokes on me, i've been using namespaces this whole time
var sheep = new Sheep();
var cow = new Cow();
var iPig = new IPig();
var mPig = new MPig();


namespace IField
{
    public class Sheep { }
    public class Pig { }
}

namespace McDroid
{
    public class Cow { }
    public class Pig { }
}