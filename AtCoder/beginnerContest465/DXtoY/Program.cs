using System.Numerics;

var t = int.Parse(Console.ReadLine());

var resultListString = new List<string>();
for (var i = 0; i < t; i++)
{
    var xyk = Console.ReadLine().Split(" ").Select(BigInteger.Parse).ToList();
    var x = xyk[0];
    var y = xyk[1];
    var k = xyk[2];

    var endCount = -1;
    var countDict = new Dictionary<string, int>();

    void loopCount(BigInteger tempX, int nowCount)
    {
        if (tempX == y)
        {
            countDict[y.ToString()] = nowCount;
            return;
        }

        var nextCount = nowCount + 1;
        // xをKで割るパターン
        var tempy1 = tempX / k;
        if (tempy1 == y)
        {
            if (countDict.TryGetValue(y.ToString(), out var value))
            {
                if (value > nextCount)
                {
                    countDict[y.ToString()] = nextCount;
                    endCount = nextCount;
                }
            }
            else
            {
                countDict[y.ToString()] = nextCount;
                endCount = nextCount;
            }
        }
        else
        {
            if (countDict.TryGetValue(tempy1.ToString(), out var value))
            {
                if (value > nextCount)
                {
                    countDict[tempy1.ToString()] = nextCount;
                    if (endCount == -1 || endCount > nextCount)
                    {
                        loopCount(tempy1, nextCount);
                    }
                }
            }
            else
            {
                countDict[tempy1.ToString()] = nextCount;
                if (endCount == -1 || endCount > nextCount)
                {
                    loopCount(tempy1, nextCount);
                }
            }
        }

        // xをKで掛けるパターン
        var tempy2 = tempX * k;
        if (tempy2 == y)
        {
            if (countDict.TryGetValue(y.ToString(), out var value))
            {
                if (value > nextCount)
                {
                    countDict[y.ToString()] = nextCount;
                    endCount = nextCount;
                }
            }
            else
            {
                countDict[y.ToString()] = nextCount;
                endCount = nextCount;
            }
        }
        else if (y * y > tempy2)
        {
            if (countDict.TryGetValue(tempy2.ToString(), out var value))
            {
                if (value > nextCount)
                {
                    countDict[tempy2.ToString()] = nextCount;
                    if (endCount == -1 || endCount > nextCount)
                    {
                        loopCount(tempy2, nextCount);
                    }
                }
            }
            else
            {
                countDict[tempy2.ToString()] = nextCount;
                if (endCount == -1 || endCount > nextCount)
                {
                    loopCount(tempy2, nextCount);
                }
            }
        }
    }

    loopCount(x, 0);
    if (countDict.TryGetValue(y.ToString(), out var value))
    {
        resultListString.Add(value.ToString());
    }
}

Console.WriteLine(string.Join("\n", resultListString));
