var hw = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var h = hw[0];
var w = hw[1];

var resultList = new List<string>();
for (var i = 0; i < h; i++)
{
    var result = "";
    for (var j = 0; j < w; j++)
    {
        if (i == 0 || i == h - 1 || j == 0 || j == w - 1)
        {
            result += "#";
        }
        else
        {
            result += ".";
        }
    }
    resultList.Add(result);
}

Console.WriteLine(string.Join("\n", resultList));
