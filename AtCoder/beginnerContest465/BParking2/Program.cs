var xylrab = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var x = xylrab[0];
var y = xylrab[1];
var l = xylrab[2];
var r = xylrab[3];
var a = xylrab[4];
var b = xylrab[5];

var result = 0;
for (var i = a; i < b; i++)
{
    if (i >= l && i < r)
    {
        result += x;
    }
    else
    {
        result += y;
    }
}

Console.WriteLine(result);
