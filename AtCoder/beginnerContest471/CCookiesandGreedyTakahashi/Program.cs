var n = int.Parse(Console.ReadLine());
var aList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

aList.Sort();
var aPlusList = new List<int>();
var aMinusList = new List<int>();
foreach (var a in aList)
{
    if (a >= 0)
    {
        aPlusList.Add(a);
    }
    else
    {
        aMinusList.Add(-a);
    }
}
aPlusList.Reverse();
var aPlusCount = aPlusList.Count;
var aMinusCount = aMinusList.Count;

var now = 0;
var result = 0L;
while (aPlusCount > 0 || aMinusCount > 0)
{
    // plus側の差分
    var tempPlusIndex = -1;
    var plusKyori = -1;
    if (aPlusCount > 0)
    {
        if (now >= 0)
        {
            plusKyori = Math.Abs(-now + aPlusList[aPlusCount - 1]);
            tempPlusIndex = aPlusCount - 1;
        }
        else
        {
            plusKyori = -now + aPlusList[aPlusCount - 1];
            tempPlusIndex = aPlusCount - 1;
        }
    }

    // minus側の差分
    var tempMinusIndex = -1;
    var minusKyori = -1;
    if (aMinusCount > 0)
    {
        if (now < 0)
        {
            var tempNow = -now;
            minusKyori = Math.Abs(tempNow - aMinusList[aMinusCount - 1]);
            tempMinusIndex = aMinusCount - 1;
        }
        else
        {
            minusKyori = now + aMinusList[aMinusCount - 1];
            tempMinusIndex = aMinusCount - 1;
        }
    }

    if (aPlusCount == 0)
    {
        result += minusKyori;
        now = -aMinusList[tempMinusIndex];
        aMinusList.RemoveAt(tempMinusIndex);
        aMinusCount--;
    }
    else if (aMinusCount == 0)
    {
        result += plusKyori;
        now = aPlusList[tempPlusIndex];
        aPlusList.RemoveAt(tempPlusIndex);
        aPlusCount--;
    }
    else
    {
        if (minusKyori <= plusKyori)
        {
            result += minusKyori;
            now = -aMinusList[tempMinusIndex];
            aMinusList.RemoveAt(tempMinusIndex);
            aMinusCount--;
        }
        else
        {
            result += plusKyori;
            now = aPlusList[tempPlusIndex];
            aPlusList.RemoveAt(tempPlusIndex);
            aPlusCount--;
        }
    }
}

Console.WriteLine(result);
