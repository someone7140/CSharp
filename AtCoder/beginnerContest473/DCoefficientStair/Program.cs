var nk = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nk[0];
var k = nk[1];

var resultList = new List<string>();
var suuretsu = new int[n];


void loopSuuretsu(int nowIndex, int zan)
{
    var indi = nowIndex + 1;
    var start = zan / indi;

    if (start == 0)
    {
        return;
    }

    if (start == 1)
    {
        if (zan % indi == 0)
        {
            suuretsu[nowIndex] = 1;
            resultList.Add(string.Join(" ", suuretsu));
            suuretsu[nowIndex] = 0;
        }
        else
        {
            if (nowIndex + 1 < n)
            {
                loopSuuretsu(nowIndex + 1, zan);
            }
        }
        return;
    }

    for (var i = start; i >= 0; i--)
    {
        suuretsu[nowIndex] = i;
        var zan2 = zan - i * indi;
        if (zan2 > 0)
        {
            if (nowIndex + 1 < n)
            {
                loopSuuretsu(nowIndex + 1, zan2);
            }
        }
        else
        {
            resultList.Add(string.Join(" ", suuretsu));
        }
        suuretsu[nowIndex] = 0;
    }
}

for (var i = k; i >= 0; i--)
{
    suuretsu[0] = i;
    var zan = k - i;
    if (zan > 0)
    {
        if (n > 1)
        {
            loopSuuretsu(1, zan);
        }
    }
    else
    {
        resultList.Add(string.Join(" ", suuretsu));
    }
}

resultList.Reverse();
Console.WriteLine(string.Join("\n", resultList));
