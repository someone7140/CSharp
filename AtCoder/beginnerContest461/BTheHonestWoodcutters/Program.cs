var n = int.Parse(Console.ReadLine());
var aList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var bList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

var result = "Yes";
for (var i = 0; i < n; i++)
{
    var a = aList[i];
    var b = bList[a - 1];
    if (i != (b - 1))
    {
        result = "No";
        break;
    }
}

Console.WriteLine(result);
