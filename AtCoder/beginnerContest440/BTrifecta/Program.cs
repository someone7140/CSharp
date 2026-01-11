var n = int.Parse(Console.ReadLine());
var tList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

var tDict = new Dictionary<int, int>();

for (var i = 0; i < n; i++)
{
    tDict[tList[i]] = i + 1;
}

tList.Sort();
var resultList = new List<string>();
for (var i = 0; i < 3; i++)
{
    resultList.Add(tDict[tList[i]].ToString());
}

Console.WriteLine(string.Join(" ", resultList));
