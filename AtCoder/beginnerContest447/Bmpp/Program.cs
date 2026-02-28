var s = Console.ReadLine();
var sList = s.ToCharArray().Select(c => c.ToString()).ToList();

var sCountDict = new Dictionary<string, int>();
var maxCount = 0;
foreach (var sChar in sList)
{
    if (!sCountDict.ContainsKey(sChar))
    {
        sCountDict[sChar] = 1;
        if (maxCount < 1)
        {
            maxCount = 1;
        }
    }
    else
    {
        sCountDict[sChar] = sCountDict[sChar] + 1;
        if (maxCount < sCountDict[sChar])
        {
            maxCount = sCountDict[sChar];
        }
    }
}

foreach (var sCount in sCountDict)
{
    if (sCount.Value == maxCount)
    {
        s = s.Replace(sCount.Key, "");
    }
}

Console.WriteLine(s);
