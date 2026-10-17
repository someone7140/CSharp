var nm = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
var n = nm[0];
var m = nm[1];

var sList = new List<string>();
var tList = new List<string>();

for (var i = 0; i < n; i++)
{
    var s = Console.ReadLine();
    sList.Add(s);
}
for (var i = 0; i < m; i++)
{
    var t = Console.ReadLine();
    tList.Add(t);
}

var countDict = new Dictionary<string, int>();

for (var i = 0; i < m; i++)
{
    var t = tList[i];
    var tMojis = t.ToCharArray().Select(c => c.ToString()).ToList();
    var findFlag = false;
    var chigauMoji = -1;
    var name = "";

    for (var j = 0; j < n; j++)
    {
        var s = sList[j];
        var sMojis = s.ToCharArray().Select(c => c.ToString()).ToList();
        var tempChigauMoji = 0;
        if (tMojis.Count == sMojis.Count)
        {
            for (var l = 0; l < sMojis.Count; l++)
            {
                if (tMojis[l] != sMojis[l])
                {
                    tempChigauMoji++;
                }
            }

            if (tempChigauMoji == 0)
            {
                findFlag = true;
                chigauMoji = 0;
                name = s;
                break;
            }
            if (tempChigauMoji == 1)
            {
                if (chigauMoji == 1)
                {
                    findFlag = false;
                }
                else
                {
                    findFlag = true;
                    chigauMoji = 1;
                    name = s;
                }
            }
        }
    }

    if (findFlag)
    {
        if (countDict.TryGetValue(name, out var val1))
        {
            countDict[name] = val1 + 1;
        }
        else
        {
            countDict[name] = 1;
        }
    }
}

var resultList = new List<string>();

for (var i = 0; i < n; i++)
{
    if (countDict.TryGetValue(sList[i], out var val1))
    {
        resultList.Add(countDict[sList[i]].ToString());
    }
    else
    {
        resultList.Add("0");
    }
}

Console.WriteLine(string.Join("\n", resultList));
