var n = int.Parse(Console.ReadLine());

var countDict = new Dictionary<string, int>();
for (var i = 0; i < n; i++)
{
    var s = Console.ReadLine().ToLower();
    if (countDict.TryGetValue(s, out var count))
    {
        countDict[s] = count + 1;
    }
    else
    {
        countDict[s] = 1;
    }
}

var result = 0;
foreach (var countElem in countDict)
{
    if (countElem.Value > result)
    {
        result = countElem.Value;
    }
}

Console.WriteLine(result);
