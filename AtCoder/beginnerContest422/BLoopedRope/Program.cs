var hw = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var h = hw[0];
var w = hw[1];

var hwListList = new List<List<string>>();
for (var i = 0; i < h; i++)
{
    var wList = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();
    hwListList.Add(wList);
}

var result = "Yes";
for (var i = 0; i < h; i++)
{
    if (result == "No")
    {
        break;
    }
    for (var j = 0; j < w; j++)
    {
        var cell = hwListList[i][j];
        if (cell == "#")
        {
            var count = 0;
            if (i > 0)
            {
                var cell2 = hwListList[i - 1][j];
                if (cell2 == "#")
                {
                    count++;
                }
            }
            if (i < h - 1)
            {
                var cell2 = hwListList[i + 1][j];
                if (cell2 == "#")
                {
                    count++;
                }
            }
            if (j > 0)
            {
                var cell2 = hwListList[i][j - 1];
                if (cell2 == "#")
                {
                    count++;
                }
            }
            if (j < w - 1)
            {
                var cell2 = hwListList[i][j + 1];
                if (cell2 == "#")
                {
                    count++;
                }
            }

            if (count is not (2 or 4))
            {
                result = "No";
                break;
            }
        }
    }
}

Console.WriteLine(result);
