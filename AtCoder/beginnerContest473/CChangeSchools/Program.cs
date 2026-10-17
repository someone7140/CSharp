var nk = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
var n = nk[0];
var k = nk[1];
var aList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

var classCountDict = new Dictionary<int, int>();

for (var i = 0; i < n; i++)
{
    if (classCountDict.TryGetValue(aList[i], out var val1))
    {
        classCountDict[aList[i]] = val1 + 1;
    }
    else
    {
        classCountDict[aList[i]] = 1;
    }
}

var countClassesDict = new Dictionary<int, int>();

foreach (var classCountElem in classCountDict)
{
    if (countClassesDict.TryGetValue(classCountElem.Value, out var val1))
    {
        countClassesDict[classCountElem.Value] = val1 + 1;
    }
    else
    {
        countClassesDict[classCountElem.Value] = 1;
    }
}

var countKeys = countClassesDict.Keys.OrderByDescending(x => x).ToList();
var result = countClassesDict[countKeys[0]];
if (countKeys.Count > 1 && countKeys[0] - countKeys[1] == 1)
{
    result += countClassesDict[countKeys[1]];
}
Console.WriteLine(result);
