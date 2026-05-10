var tx = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var t = tx[0];
var x = tx[1];

var aList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var resultList = new List<string>();
var before = -1;
for (var i = 0; i <= t; i++)
{
    if (i == 0)
    {
        resultList.Add(i.ToString() + " " + aList[i]);
        before = aList[i];
        continue;
    }

    var sabun = Math.Abs(aList[i] - before);
    if (x > sabun)
    {
        continue;
    }

    resultList.Add(i.ToString() + " " + aList[i]);
    before = aList[i];
}

Console.WriteLine(string.Join("\n", resultList));
