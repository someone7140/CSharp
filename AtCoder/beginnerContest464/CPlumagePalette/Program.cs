var nm = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nm[0];
var m = nm[1];

var syuruiCount = 0;

var syuruiCountDict = new Dictionary<int, int>();
var dayCahngeDict = new Dictionary<int, List<ChangeColor>>();

for (var i = 1; i <= n; i++)
{
    syuruiCountDict[i] = 0;
}

for (var i = 0; i < n; i++)
{
    var adb = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var a = adb[0];
    var d = adb[1];
    var b = adb[2];

    if (syuruiCountDict.TryGetValue(a, out var count))
    {
        if (count == 0)
        {
            syuruiCount++;
        }
        syuruiCountDict[a] = count + 1;

    }

    if (dayCahngeDict.TryGetValue(d, out var changes))
    {
        changes.Add(new ChangeColor
        {
            Before = a,
            After = b
        });
    }
    else
    {
        dayCahngeDict[d] = [new ChangeColor
        {
            Before = a,
            After = b
        }];
    }
}

var resultList = new List<string>();

for (var i = 1; i <= m; i++)
{
    if (dayCahngeDict.TryGetValue(i, out var changes))
    {
        foreach (var change in changes)
        {
            var beforeCount = syuruiCountDict[change.Before];
            if (beforeCount == 1)
            {
                syuruiCount--;
            }
            syuruiCountDict[change.Before] = beforeCount - 1;

            var afterCount = syuruiCountDict[change.After];
            if (afterCount == 0)
            {
                syuruiCount++;
            }
            syuruiCountDict[change.After] = afterCount + 1;
        }

        resultList.Add(syuruiCount.ToString());
    }
    else
    {
        resultList.Add(syuruiCount.ToString());
    }
}

Console.WriteLine(string.Join("\n", resultList));

class ChangeColor
{
    public required int Before { get; set; }

    public required int After { get; set; }
}

