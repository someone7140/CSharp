var nm = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nm[0];
var m = nm[1];

var maxDict = new Dictionary<int, int>();
for (var i = 0; i < n; i++)
{
    var cs = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var c = cs[0];
    var s = cs[1];

    if (maxDict.TryGetValue(c, out var value))
    {
        if (s > value)
        {
            maxDict[c] = s;
        }
    }
    else
    {
        maxDict[c] = s;
    }
}

var resultListString = new List<string>();
for (var i = 1; i <= m; i++)
{
    if (maxDict.TryGetValue(i, out var value))
    {
        resultListString.Add(value.ToString());
    }
    else
    {
        resultListString.Add("-1");
    }
}

Console.WriteLine(string.Join(" ", resultListString));
