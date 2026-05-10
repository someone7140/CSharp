var nk = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
var n = (int)nk[0];
var k = nk[1];

var aListList = new List<List<long>>();
var aCountList = new List<long>();
for (var i = 0; i < n; i++)
{
    var aList = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
    aCountList.Add(aList[0]);
    aList.RemoveAt(0);
    aListList.Add(aList);
}

var cList = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
var nowCount = 0L;
var result = 0L;
for (var i = 0; i < n; i++)
{
    var plusCount = cList[i] * aCountList[i];
    nowCount += plusCount;
    if (nowCount >= k)
    {
        var sabun = nowCount - k;
        var index = (int)((plusCount - sabun - 1) % aCountList[i]);
        result = aListList[i][index];
        break;
    }
}

Console.WriteLine(result);
