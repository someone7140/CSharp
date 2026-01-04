var n = int.Parse(Console.ReadLine());
var aStrArray = Console.ReadLine().Split(" ");
var aDict = new Dictionary<long, List<int>>();

for (var i = 0; i < n; i++)
{
    var a = long.Parse(aStrArray[i]);
    if (aDict.ContainsKey(a))
    {
        aDict[a].Add(i);
    }
    else
    {
        aDict[a] = [i];
    }
}

var keisuu = 1L;
var result = 0L;

while (10000000L >= keisuu * 7L)
{
    var seven = keisuu * 7;
    var five = keisuu * 5;
    var three = keisuu * 3;

    keisuu++;
    var sevenList = new List<int>();
    var fiveList = new List<int>();
    var threeList = new List<int>();
    if (aDict.ContainsKey(seven))
    {
        sevenList = aDict[seven];
    }
    else
    {
        continue;
    }
    if (aDict.ContainsKey(five))
    {
        fiveList = aDict[five];
    }
    else
    {
        continue;
    }
    if (aDict.ContainsKey(three))
    {
        threeList = aDict[three];
    }
    else
    {
        continue;
    }

    // 判定
    foreach (int fiveIndex in fiveList)
    {

        if (sevenList[0] > fiveIndex && threeList[0] > fiveIndex)
        {
            // minだけ判定
            result += (long)sevenList.Count * (long)threeList.Count;
        }
        else if (sevenList[0] > fiveIndex)
        {
            result += (long)sevenList.Count * (long)(threeList.Count - (LowerMaxIndex(threeList, fiveIndex) + 1));
        }
        else if (threeList[0] > fiveIndex)
        {
            result += (long)threeList.Count * (long)(sevenList.Count - (LowerMaxIndex(sevenList, fiveIndex) + 1));
        }
        else
        {
            var sevenMaxIndex = sevenList.Last();
            var threeMaxIndex = threeList.Last();
            if (fiveIndex > sevenMaxIndex && fiveIndex > threeMaxIndex)
            {
                result += (long)sevenList.Count * (long)threeList.Count;
            }
            else if (fiveIndex > sevenMaxIndex)
            {
                result += (long)sevenList.Count * (long)(LowerMaxIndex(threeList, fiveIndex) + 1);
            }
            else if (fiveIndex > threeMaxIndex)
            {
                result += (long)(LowerMaxIndex(sevenList, fiveIndex) + 1) * (long)threeList.Count;
            }
            else
            {
                result += (long)(LowerMaxIndex(sevenList, fiveIndex) + 1) * (long)(LowerMaxIndex(threeList, fiveIndex) + 1);
                result += (long)(sevenList.Count - (LowerMaxIndex(sevenList, fiveIndex) + 1)) * (long)(threeList.Count - (LowerMaxIndex(threeList, fiveIndex) + 1));
            }
        }

    }

}

Console.WriteLine(result);


static int LowerMaxIndex(List<int> indexList, int targetIndex)
{
    if (indexList[0] >= targetIndex)
    {
        return 0;
    }

    var first = 0;
    var last = indexList.Count - 1;
    var half = last / 2;
    var loopFlag = true;
    while (loopFlag)
    {

        if (indexList[half] > targetIndex)
        {
            last = half;

        }
        if (indexList[half] <= targetIndex)
        {
            first = half;
        }
        half = (first + last) / 2;
        if (half >= first || half <= last || first >= last)
        {
            loopFlag = false;
        }
    }
    return half;
}