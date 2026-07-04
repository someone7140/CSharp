var n = int.Parse(Console.ReadLine());

var sortedList = new SortedList<int, HashSet<int>>();
var timeSet = new HashSet<int>();
var dictTime = new Dictionary<int, List<int>>();
var dictH = new Dictionary<int, HashSet<int>>();

for (var i = 0; i < n; i++)
{
    var hl = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var h = hl[0];
    var l = hl[1];

    timeSet.Add(l);

    if (dictH.TryGetValue(h, out var value))
    {
        value.Add(l);
    }
    else
    {
        dictH[h] = [l];
    }

    sortedList[h] = dictH[h];

    if (dictTime.TryGetValue(l, out var value2))
    {
        value2.Add(h);
    }
    else
    {
        dictTime[l] = [h];
    }
}

var q = int.Parse(Console.ReadLine());
var queries = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

var timeList = timeSet.ToList();
timeList.Sort();
var minTime = timeList[0];
var maxAll = sortedList.GetKeyAtIndex(sortedList.Count - 1);

var timeMaxDict = new Dictionary<int, int>();
foreach (var time in timeList)
{
    var keys = dictTime[time];
    foreach (var key in keys)
    {
        if (sortedList.TryGetValue(key, out var values))
        {
            values.Remove(time);
            if (values.Count == 0)
            {
                sortedList.Remove(key);
            }
        }
    }
    var count = sortedList.Count;
    if (count > 0)
    {
        var max = sortedList.GetKeyAtIndex(count - 1);
        timeMaxDict[time] = max;
    }
}

var resultList = new List<string>();
foreach (var query in queries)
{
    if (query < minTime)
    {
        resultList.Add(maxAll.ToString());
    }
    else
    {
        var targetTime = -1;
        var targetTimeIndex = timeList.BinarySearch(query);
        if (targetTimeIndex < 0)
        {
            targetTimeIndex = ~targetTimeIndex - 1;
            targetTime = timeList[targetTimeIndex];
        }
        else
        {
            targetTime = timeList[targetTimeIndex];
        }
        resultList.Add(timeMaxDict[targetTime].ToString());
    }
}

Console.WriteLine(string.Join("\n", resultList));
