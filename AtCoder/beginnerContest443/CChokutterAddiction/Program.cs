var nt = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
var n = nt[0];
var t = nt[1];
if (n == 0)
{
    Console.WriteLine(t);
    return;
}

var aList = Console.ReadLine().Split(" ").Select(long.Parse).ToList();

var resultTime = 0L;
var nextOpenTime = 0L;
foreach (int a in aList)
{
    if (a >= nextOpenTime)
    {
        resultTime += a - nextOpenTime;
        nextOpenTime = a + 100;
    }

}
if (nextOpenTime < t)
{
    resultTime += t - nextOpenTime;
}

Console.WriteLine(resultTime);
