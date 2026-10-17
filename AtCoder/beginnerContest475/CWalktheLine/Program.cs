var nsl = Console.ReadLine().Split(" ").ToList();
var n = int.Parse(nsl[0]);
var s = int.Parse(nsl[1]);
var l = long.Parse(nsl[2]);

var aList = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
var leftSumList = new List<long>();
var rightSumList = new List<long>();

// 左に行く
if (s > 1)
{
    var tempSum = 0L;
    for (var i = s - 2; i >= 0; i--)
    {
        tempSum += aList[i];
        leftSumList.Add(tempSum);
    }
}

// 右に行く
if (s < n)
{
    var tempSum2 = 0L;
    for (var i = s - 1; i < n - 1; i++)
    {
        tempSum2 += aList[i];
        rightSumList.Add(tempSum2);
    }
}

var result = 1;
var leftLen = leftSumList.Count;
var rightLen = rightSumList.Count;

if (leftLen > 0 && rightLen > 0)
{
    for (var i = 0; i <= leftLen; i++)
    {
        var tempResult = 0;
        var tempSum = 0L;
        if (i > 0)
        {
            tempSum = leftSumList[i - 1];
            tempResult += i;
        }

        if (tempSum > l)
        {
            break;
        }
        if (tempSum * 2 < l)
        {
            var nokori = l - tempSum * 2;
            var rightIndex = rightSumList.BinarySearch(nokori);
            if (rightIndex < 0)
            {
                rightIndex = ~rightIndex;
            }
            else
            {
                rightIndex++;
            }

            tempResult += rightIndex;
        }

        tempResult++;
        if (tempResult > result)
        {
            result = tempResult;
        }
    }

    for (var i = 0; i <= rightLen; i++)
    {
        var tempResult = 0;
        var tempSum = 0L;
        if (i > 0)
        {
            tempSum = rightSumList[i - 1];
            tempResult += i;
        }

        if (tempSum > l)
        {
            break;
        }
        if (tempSum * 2 < l)
        {
            var nokori = l - tempSum * 2;
            var leftIndex = leftSumList.BinarySearch(nokori);
            if (leftIndex < 0)
            {
                leftIndex = ~leftIndex;
            }
            else
            {
                leftIndex++;
            }

            tempResult += leftIndex;
        }

        tempResult++;
        if (tempResult > result)
        {
            result = tempResult;
        }
    }
}
else if (leftLen > 0)
{
    var leftIndex = leftSumList.BinarySearch(l);
    if (leftIndex < 0)
    {
        leftIndex = ~leftIndex;
    }
    else
    {
        leftIndex++;
    }

    result += leftIndex;
}
else if (rightLen > 0)
{
    var rightIndex = rightSumList.BinarySearch(l);
    if (rightIndex < 0)
    {
        rightIndex = ~rightIndex;
    }
    else
    {
        rightIndex++;
    }

    result += rightIndex;
}

Console.WriteLine(result);
