var n = int.Parse(Console.ReadLine());
var aList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

var uvDict = new Dictionary<int, List<int>>();
for (var i = 0; i < n - 1; i++)
{
    var uv = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var u = uv[0] - 1;
    var v = uv[1] - 1;

    if (!uvDict.ContainsKey(u))
    {
        uvDict[u] = [v];
    }
    else
    {
        uvDict[u].Add(v);
    }

    if (!uvDict.ContainsKey(v))
    {
        uvDict[v] = [u];
    }
    else
    {
        uvDict[v].Add(u);
    }
}

var alreadyCheckList = new HashSet<int>();
var uvUpperDict = new Dictionary<int, int>();
loopTree(0);

var resultList = new List<string>
{
    "No"
};

for (var i = 1; i < n; i++)
{
    var tempResult = "No";
    var aSet = new HashSet<int>
    {
        aList[i]
    };

    var upperIndex = i;
    while (true)
    {
        upperIndex = uvUpperDict[upperIndex];
        if (aSet.Contains(aList[upperIndex]))
        {
            tempResult = "Yes";
            break;
        }
        if (upperIndex == 0)
        {
            break;
        }
        aSet.Add(aList[upperIndex]);
    }
    resultList.Add(tempResult);
}

Console.WriteLine(string.Join("\n", resultList));


void loopTree(int targetIndex)
{
    if (alreadyCheckList.Contains(targetIndex))
    {
        return;
    }
    alreadyCheckList.Add(targetIndex);
    var toList = uvDict[targetIndex];
    foreach (var to in toList)
    {
        if (!alreadyCheckList.Contains(to))
        {
            uvUpperDict[to] = targetIndex;
            loopTree(to);
        }
    }
}
