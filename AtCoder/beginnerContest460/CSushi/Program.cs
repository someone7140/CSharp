var nm = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nm[0];
var m = nm[1];

var aList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
aList.Sort();

var bList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
bList.Sort();

var result = 0L;
var nowAIndex = 0;
var nowBIndex = 0;

while (nowAIndex < n && nowBIndex < m)
{
    var a = aList[nowAIndex];
    var b = bList[nowBIndex];

    if (2 * a >= b)
    {
        nowAIndex++;
        nowBIndex++;
        result++;
    }
    else
    {
        nowAIndex++;
    }
}

Console.WriteLine(result);
