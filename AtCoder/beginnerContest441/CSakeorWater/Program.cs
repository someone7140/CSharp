var nkx = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
var n = nkx[0];
var k = nkx[1];
var x = nkx[2];

var aList = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
aList.Sort();
var aSumArray = new long[n];

for (var i = 0; i < n; i++)
{
    if (i == 0)
    {
        aSumArray[0] = aList[0];
    }
    else
    {
        aSumArray[i] = aList[i] + aSumArray[i - 1];
    }

}

var nowSum = 0L;
var resultIndex = 0L;

for (var i = 0; i < k; i++)
{
    resultIndex = i;
    nowSum = aSumArray[i];
    if (aSumArray[i] >= x)
    {
        break;
    }
}

var result = 0L;
if (nowSum < x)
{
    result = -1;
}
else
{
    result = resultIndex + 1 + n - k;
}

Console.WriteLine(result);
