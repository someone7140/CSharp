var hw = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var h = hw[0];
var w = hw[1];

var resultArray = new string[h];
for (var i = 0; i < h; i++)
{
    var result1 = 4;
    var tempArray = new string[w];
    if (i == 0)
    {
        result1--;
    }
    if (i == h - 1)
    {
        result1--;
    }

    for (var j = 0; j < w; j++)
    {
        var result2 = result1;
        if (j == 0)
        {
            result2--;
        }
        if (j == w - 1)
        {
            result2--;
        }
        tempArray[j] = result2.ToString();
    }

    resultArray[i] = string.Join(" ", tempArray);
}

Console.WriteLine(string.Join("\n", resultArray));
