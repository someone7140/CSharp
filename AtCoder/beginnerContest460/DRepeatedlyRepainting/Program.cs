var hw = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var h = hw[0];
var w = hw[1];

var orderedDict = new OrderedDictionary<string, int>();
var nowListList = new List<List<string>>();

var nowSMojiList = new List<string>();
for (var i = 0; i < h; i++)
{
    var s = Console.ReadLine();
    nowSMojiList.Add(s);
    var sList = s.ToCharArray().Select(c => c.ToString()).ToList();
    nowListList.Add(sList);
}

var nowIndex = 1;
orderedDict[string.Join("", nowSMojiList)] = nowIndex;

while (true)
{
    // 反転処理
    var nextListList = new List<List<string>>();
    var tempSMojiList = new List<string>();
    for (var i = 0; i < h; i++)
    {
        var nextList = new List<string>();
        for (var j = 0; j < w; j++)
        {
            var masu = nowListList[i][j];
            if (masu == "#")
            {
                nextList.Add(".");
            }
            else
            {
                var hantenFlag = false;
                if (i != 0)
                {
                    var masuList = nowListList[i - 1];
                    if (masuList[j] == "#")
                    {
                        hantenFlag = true;
                    }
                    if (j != 0)
                    {
                        if (masuList[j - 1] == "#")
                        {
                            hantenFlag = true;
                        }
                    }
                    if (j != w - 1)
                    {
                        if (masuList[j + 1] == "#")
                        {
                            hantenFlag = true;
                        }
                    }
                }

                if (i != h - 1 && !hantenFlag)
                {
                    var masuList = nowListList[i + 1];
                    if (masuList[j] == "#")
                    {
                        hantenFlag = true;
                    }
                    if (j != 0)
                    {
                        if (masuList[j - 1] == "#")
                        {
                            hantenFlag = true;
                        }
                    }
                    if (j != w - 1)
                    {
                        if (masuList[j + 1] == "#")
                        {
                            hantenFlag = true;
                        }
                    }
                }

                if (j != 0 && !hantenFlag)
                {
                    if (nowListList[i][j - 1] == "#")
                    {
                        hantenFlag = true;
                    }
                }

                if (j != w - 1 && !hantenFlag)
                {
                    if (nowListList[i][j + 1] == "#")
                    {
                        hantenFlag = true;
                    }
                }

                if (hantenFlag)
                {
                    nextList.Add("#");
                }
                else
                {
                    nextList.Add(".");
                }
            }
        }
        tempSMojiList.Add(string.Join("", nextList));
        nextListList.Add(nextList);
    }

    var nowMoji = string.Join("", nowSMojiList);
    var tempMoji2 = string.Join("", tempSMojiList);

    if (nowMoji == tempMoji2)
    {
        Console.WriteLine(string.Join("\n", nowSMojiList));
        return;
    }
    else if (!orderedDict.ContainsKey(tempMoji2))
    {
        orderedDict[string.Join("", tempSMojiList)] = nowIndex + 1;
        nowIndex++;
        nowListList = nextListList;
        nowSMojiList = tempSMojiList;
    }
    else
    {
        break;
    }
}

var dictCount = orderedDict.Count;
var dictKeys = orderedDict.Keys.ToList();

var tenCount = 1;
var upperTen = 10;

while (true)
{
    if (upperTen >= dictCount)
    {
        break;
    }
    else
    {
        tenCount++;
        upperTen *= 10;
    }
}

var amari = upperTen % dictCount;
var nowAmari = amari;

if (amari != 0)
{
    for (var i = tenCount; i <= 100; i += tenCount)
    {
        nowAmari = nowAmari * upperTen % amari;
    }

}

var target = nowAmari;

if (target == 0)
{
    target = dictCount;
}
var resultMoji = dictKeys[target - 1];
var resultList = new List<string>();
var tempMoji = "";
for (var i = 0; i < h * w; i++)
{
    var masuMoji = resultMoji[i].ToString();
    tempMoji += masuMoji;
    if ((i + 1) % w == 0)
    {
        resultList.Add(tempMoji);
        tempMoji = "";
    }
}

Console.WriteLine(string.Join("\n", resultList));
