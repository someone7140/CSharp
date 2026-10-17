var nmk = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
var n = (int)nmk[0];
var m = (int)nmk[1];
var k = nmk[2];

var aList = Console.ReadLine().Split(" ").Select(long.Parse).ToList();

var okashiArray = new long[m];
var nowPosition = 0;
var sum = 0L;

var resultList = new List<string>();
for (var i = 0; i < n; i++)
{
    var tempSum = sum + (aList[i] - okashiArray[nowPosition]);

    if (tempSum <= k)
    {
        sum = tempSum;
        okashiArray[nowPosition] = aList[i];
        resultList.Add("Yes");
    }
    else
    {
        tempSum -= aList[i];
        sum = tempSum;
        okashiArray[nowPosition] = 0;
        resultList.Add("No");
    }

    if (nowPosition == m - 1)
    {
        nowPosition = 0;
    }
    else
    {
        nowPosition++;
    }
}

Console.WriteLine(string.Join("\n", resultList));
