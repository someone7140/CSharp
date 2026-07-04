var hw = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var h = hw[0];
var w = hw[1];

var cListLst = new List<List<string>>();
for (var i = 0; i < h; i++)
{
    var cList = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();
    cListLst.Add(cList);
}

// 上の行を削除
while (true)
{
    var cList = cListLst[0];
    var includePix = cList.Any(c => c == "#");
    if (!includePix)
    {
        cListLst.RemoveAt(0);
    }
    else
    {
        break;
    }
}

// 下の行を削除
while (true)
{
    var cList = cListLst[^1];
    var includePix = cList.Any(c => c == "#");
    if (!includePix)
    {
        cListLst.RemoveAt(cListLst.Count - 1);
    }
    else
    {
        break;
    }
}

// 左の列を削除
while (true)
{
    var includePix = false;
    foreach (var cList in cListLst)
    {
        if (cList[0] == "#")
        {
            includePix = true;
            break;
        }
    }

    if (includePix)
    {
        break;
    }
    else
    {
        foreach (var cList in cListLst)
        {
            cList.RemoveAt(0);
        }
    }
}


// 右の列を削除
while (true)
{
    var includePix = false;
    foreach (var cList in cListLst)
    {
        if (cList[^1] == "#")
        {
            includePix = true;
            break;
        }
    }

    if (includePix)
    {
        break;
    }
    else
    {
        foreach (var cList in cListLst)
        {
            cList.RemoveAt(cList.Count - 1);
        }
    }
}

var resultList = new List<string>();
foreach (var cList in cListLst)
{
    resultList.Add(string.Join("", cList));
}
Console.WriteLine(string.Join("\n", resultList));
