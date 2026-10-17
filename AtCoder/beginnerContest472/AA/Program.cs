var aStringList = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();
var result = "";

foreach (var a in aStringList)
{
    if (a == "A")
    {
        result += a;
    }
    else
    {
        result += ".";
    }
}

Console.WriteLine(result);
