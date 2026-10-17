var n = int.Parse(Console.ReadLine());
var aList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

var countDict = new Dictionary<int, int>();

for (var i = 0; i < n; i++)
{
    if (countDict.TryGetValue(aList[i], out var val1))
    {
        countDict[aList[i]] = val1 + 1;
    }
    else
    {
        countDict[aList[i]] = 1;
    }

}

var result = 0;
foreach (var countElem in countDict)
{
    if (countElem.Value % 2 != 0)
    {
        result += countElem.Key;
    }
}

Console.WriteLine(result);
