var nk = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
var n = (int)nk[0];
var k = nk[1];

var aList = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
aList.Sort();

var aCountDict = new Dictionary<long, CountInfo>();
var aSortedSet = new SortedSet<long>();
var before = -1L;
var tempCount = 0L;

for (var i = 0; i < n; i++)
{
    if (aList[i] == before || before == -1L)
    {
        tempCount++;
    }
    else if (i == n - 1)
    {
        if (aList[i] == before)
        {
            tempCount++;
            aCountDict[aList[i]] = new CountInfo
            {
                Count = tempCount,
                Increase = aList[i],
            };
            aSortedSet.Add(aList[i]);
        }
        else
        {
            aCountDict[before] = new CountInfo
            {
                Count = tempCount,
                Increase = before,
            };
            aCountDict[aList[i]] = new CountInfo
            {
                Count = 1,
                Increase = aList[i],
            };
            aSortedSet.Add(before);
            aSortedSet.Add(aList[i]);
        }
    }
    else
    {
        aCountDict[before] = new CountInfo
        {
            Count = tempCount,
            Increase = before,
        };
        aSortedSet.Add(before);
        tempCount = 1;
        before = aList[i];
    }
}

var count = 0L;
var result = 0L;

while (count <= k)
{
    // 最小値
    var min = aSortedSet.First();
    aSortedSet.Remove(min);
    // カウント情報
    var countInfo = aCountDict[min];
    if (aSortedSet.Count > 0)
    {
        var min2 = aSortedSet.First();
        // 何回増やせるか
        var wari = (k - count) / countInfo.Count;
        var beforeWari = min2 / countInfo.Increase;
        if (wari <= beforeWari)
        {
            result = min + wari * countInfo.Increase;
        }
        else
        {
            var incCount = countInfo.Count * beforeWari;
            var next = min + beforeWari * countInfo.Increase;

        }
    }
    else
    {
        // 何回増やせるか
        var wari = k / countInfo.Count;
        result = min + wari * countInfo.Increase;
    }
}

Console.WriteLine(result);

class CountInfo
{
    public required long Count { get; set; }

    public required long Increase { get; set; }
}
