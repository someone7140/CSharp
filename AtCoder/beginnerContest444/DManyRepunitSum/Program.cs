var n = int.Parse(Console.ReadLine());
var aList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var aCountList = new int[200000];
var aCountSumList = new int[200000];

var max = -1;
for (var i = 0; i < n; i++)
{
    if (max < aList[i])
    {
        max = aList[i];
    }
    aCountList[aList[i] - 1] = aCountList[aList[i] - 1] + 1;
}

for (var i = max - 1; i >= 0; i--)
{
    if (i == max - 1)
    {
        aCountSumList[i] = aCountList[i];
    }
    else
    {
        aCountSumList[i] = aCountList[i] + aCountSumList[i + 1];
    }
}

var nextCount = 0;
var result = "";
for (var i = 0; i < max; i++)
{
    var tempCount = aCountSumList[i] + nextCount;
    var amari = tempCount % 10;
    nextCount = tempCount / 10;
    result += amari.ToString();
    if (i == n - 1)
    {
        while (nextCount > 0)
        {
            amari = nextCount % 10;
            nextCount = tempCount / 10;
            result += amari.ToString();
        }
    }
}

Console.WriteLine(string.Join("", result.ToCharArray().Reverse()));
