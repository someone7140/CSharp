var nd = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nd[0];
var d = nd[1];

var xList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var resultList = new List<string>();

for (var i = 0; i < n; i++)
{
    var issenFlag = true;
    for (var j = 0; j < n; j++)
    {
        if (i != j)
        {
            var sabun = Math.Abs(xList[i] - xList[j]);
            if (sabun < d)
            {
                issenFlag = false;
                break;
            }
        }
    }

    if (issenFlag)
    {
        resultList.Add((i + 1).ToString());
    }
}

Console.WriteLine(resultList.Count);
Console.WriteLine(string.Join(" ", resultList));
