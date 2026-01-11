var t = int.Parse(Console.ReadLine());

var resultList = new List<string>();
for (var i = 0; i < t; i++)
{
    var nw = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var n = nw[0];
    var w = nw[1];

    var cStrList = Console.ReadLine().Split(" ").ToList();
    var cArray = new long[n];
    var cSumArray = new long[n];
    var sum = 0L;
    for (var j = 0; j < n; j++)
    {
        var c = long.Parse(cStrList[j]);
        cArray[j] = c;
        cSumArray[j] = sum + c;
        sum += c;
    }

    if (n <= w)
    {
        resultList.Add("0");
        continue;
    }

    var result = 0L;
    // 最初をいくつ塗るかでループ
    for (var j = 0; j <= w; j++)
    {
        var nowIndex = 0;
        var tempResult = 0L;
        if (j == 0)
        {
            nowIndex = w;
        }
        else
        {
            tempResult = cSumArray[j - 1];
            nowIndex = j + w;
        }
        while (true)
        {
            if (nowIndex > n - 1)
            {
                break;
            }

            var endIndex = nowIndex + w - 1 > n - 1 ? n - 1 : nowIndex + w - 1;
            var minusSum = nowIndex == 0 ? 0 : cSumArray[nowIndex - 1];
            var plusSum = cSumArray[endIndex];
            tempResult += plusSum - minusSum;
            nowIndex += 2 * w;
        }

        if (result == 0L || tempResult < result)
        {
            result = tempResult;
        }
    }
    resultList.Add(result.ToString());
}

Console.WriteLine(string.Join("\n", resultList));
