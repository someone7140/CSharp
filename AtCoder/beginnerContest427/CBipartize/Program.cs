var nm = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nm[0];
var m = nm[1];

var uvDict = new Dictionary<int, List<int>>();
for (var i = 0; i < m; i++)
{
    var uv = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var u = uv[0];
    var v = uv[1];

    if (!uvDict.ContainsKey(u))
    {
        uvDict[u] = [v];
    }
    else
    {
        uvDict[u] = [.. uvDict[u].Append(v)];
    }
}

var flag = 1;
var max = (int)Math.Pow(2, n);
var result = 999999999;
while (flag <= max)
{
    var flagList = Convert.ToString(flag, 2).PadLeft(n, '0').ToArray().Select(c => c.ToString()).ToArray();
    var tempResult = 0;
    foreach (KeyValuePair<int, List<int>> uv in uvDict)
    {
        var keyColor = flagList[uv.Key - 1];
        foreach (int val in uv.Value)
        {
            var valColor = flagList[val - 1];
            if (keyColor == valColor)
            {
                tempResult++;
            }
        }
    }

    if (tempResult < result)
    {
        result = tempResult;
    }
    flag++;
}

Console.WriteLine(result);
