var t = int.Parse(Console.ReadLine());
var resultList = new List<string>();

for (var i = 0; i < t; i++)
{
    var n = int.Parse(Console.ReadLine());
    var aList = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
    var min = aList.Min();
    var minIndex = aList.IndexOf(min);
    var tempResult = 0L;


    if (minIndex > 0)
    {
        var before = min;
        for (var j = minIndex; j >= 0; j--)
        {
            var sabun = Math.Abs(aList[j] - before);
            if (sabun > 1)
            {
                if (aList[j] < before)
                {
                    tempResult += sabun - 1;
                    before = aList[j];
                }
                else
                {
                    tempResult += sabun - 1;
                    before = before + 1;
                }

            }
            else
            {
                before = aList[j];
            }
        }
    }
    if (minIndex < n - 1)
    {
        var before = min;
        for (var j = minIndex; j < n; j++)
        {
            var sabun = Math.Abs(aList[j] - before);
            if (sabun > 1)
            {
                if (aList[j] < before)
                {
                    tempResult += sabun - 1;
                    before = aList[j];
                }
                else
                {
                    tempResult += sabun - 1;
                    before = before + 1;
                }

            }
            else
            {
                before = aList[j];
            }
        }
    }
    resultList.Add(tempResult.ToString());
}

Console.WriteLine(string.Join("\n", resultList));
