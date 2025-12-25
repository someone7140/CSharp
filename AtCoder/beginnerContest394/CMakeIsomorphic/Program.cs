var n = int.Parse(Console.ReadLine());
var m = int.Parse(Console.ReadLine());
var gDict = new Dictionary<int, List<int>>();
for (var i = 0; i < m; i++)
{
    var uvArray = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var u = uvArray[0] - 1;
    var v = uvArray[1] - 1;
    if (!gDict.ContainsKey(u))
    {
        gDict[u] = [v];
    }
    else
    {
        gDict[u] = [.. gDict[u].Append(v).OrderBy(v => v)];
    }

    if (!gDict.ContainsKey(v))
    {
        gDict[v] = [u];
    }
    else
    {
        gDict[v] = [.. gDict[v].Append(u).OrderBy(num => num)];
    }
}

m = int.Parse(Console.ReadLine());
var hDict = new Dictionary<int, List<int>>();
for (var i = 0; i < m; i++)
{
    var uvArray = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var u = uvArray[0] - 1;
    var v = uvArray[1] - 1;
    if (!hDict.ContainsKey(u))
    {
        hDict[u] = [v];
    }
    else
    {
        hDict[u] = [.. hDict[u].Append(v).OrderBy(v => v)];
    }

    if (!hDict.ContainsKey(v))
    {
        hDict[v] = [u];
    }
    else
    {
        hDict[v] = [.. hDict[v].Append(u).OrderBy(num => num)];
    }
}

var costListList = new List<List<int>>();
for (var i = 0; i < n - 1; i++)
{
    var aArray = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    costListList.Add(aArray);
}

var result = 999999999;
var patterns = Enumerate(Enumerable.Range(0, n));
foreach (int[] pattern in patterns)
{
    var dictHCopy = new Dictionary<int, List<int>>(hDict);
    var tempResult = 0;
    for (var i = 0; i < n - 1; i++)
    {
        var gList = gDict[i];
        var hList = hDict[pattern[i]];
        foreach (int g in gList)
        {
            var findFlag = false;
            foreach (int h in hList)
            {
                if (h == pattern[g])
                {
                    findFlag = true;
                }
            }
            if (!findFlag)
            {
                if (pattern[i] < pattern[g])
                {
                    tempResult += costListList[pattern[i]][pattern[g] - pattern[i] - 1];
                }
                else
                {
                    tempResult += costListList[pattern[g]][pattern[i] - pattern[g] - 1];
                }
            }
        }

        foreach (int h in hList)
        {
            var findFlag = false;
            foreach (int g in gList)
            {
                if (h != pattern[g])
                {
                    findFlag = true;
                    break;
                }
            }
            if (!findFlag)
            {
                if (pattern[i] < pattern[h])
                {
                    tempResult += costListList[pattern[i]][pattern[h] - pattern[i] - 1];
                }
                else
                {
                    tempResult += costListList[pattern[h]][pattern[i] - pattern[h] - 1];
                }
            }
        }

        tempResult /= 2;
        if (tempResult < result)
        {
            tempResult = result;
        }
    }
}
Console.WriteLine(result);

static IEnumerable<T[]> Enumerate<T>(IEnumerable<T> items)
{
    if (items.Count() == 1)
    {
        yield return new T[] { items.First() };
        yield break;
    }
    foreach (var item in items)
    {
        var leftside = new T[] { item };
        var unused = items.Except(leftside);
        foreach (var rightside in Enumerate(unused))
        {
            yield return leftside.Concat(rightside).ToArray();
        }
    }
}