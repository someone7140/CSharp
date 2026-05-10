var n = int.Parse(Console.ReadLine());
var lList = Console.ReadLine().Split(" ").Select(double.Parse).ToList();

var now = 0.5;
var isPlus = true;
var result = -1;

loopTree(0, 0.5, 0);
Console.WriteLine(result);

void loopTree(int targetIndex, double beforeValue, int tempResult)
{
    var beforePlusFlag = beforeValue >= 0;
    var nowMinusVal = beforeValue - lList[targetIndex];
    var nowMinusValPlusFlag = nowMinusVal >= 0;
    var nowPlusVal = beforeValue + lList[targetIndex];
    var nowPlusValPlusFlag = nowPlusVal >= 0;

    if (targetIndex < n - 1)
    {
        var tempMinusResult = tempResult;
        if (beforePlusFlag != nowMinusValPlusFlag)
        {
            tempMinusResult += 1;
        }
        loopTree(targetIndex + 1, nowMinusVal, tempMinusResult);

        var tempPlusResult = tempResult;
        if (beforePlusFlag != nowPlusValPlusFlag)
        {
            tempPlusResult += 1;
        }
        loopTree(targetIndex + 1, nowPlusVal, tempPlusResult);
    }
    else
    {
        var tempLastResult = tempResult;
        if (beforePlusFlag != nowMinusValPlusFlag)
        {
            tempLastResult += 1;
        }
        else if (beforePlusFlag != nowPlusValPlusFlag)
        {
            tempLastResult += 1;
        }

        if (tempLastResult > result)
        {
            result = tempLastResult;
        }
    }
}
