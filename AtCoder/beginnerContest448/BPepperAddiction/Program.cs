var nm = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nm[0];
var m = nm[1];
var cList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

var abDict = new Dictionary<int, int>();
for (var i = 0; i < n; i++)
{
    var ab = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var a = ab[0];
    var b = ab[1];

    if (!abDict.ContainsKey(a))
    {
        abDict[a] = b;
    }
    else
    {
        abDict[a] += b;
    }

}

var result = 0;
for (var i = 0; i < m; i++)
{
    if (abDict.ContainsKey(i + 1))
    {
        var pepper = Math.Min(abDict[i + 1], cList[i]);
        result += pepper;
    }

}
Console.WriteLine(result);
