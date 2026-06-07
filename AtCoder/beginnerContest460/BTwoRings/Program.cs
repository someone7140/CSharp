var t = int.Parse(Console.ReadLine());
var resultList = new List<string>();

for (var i = 0; i < t; i++)
{
    var cases = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
    var x1 = cases[0];
    var y1 = cases[1];
    var r1 = cases[2];
    var x2 = cases[3];
    var y2 = cases[4];
    var r2 = cases[5];

    var chuushinKyori = (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
    var hankei = (r1 + r2) * (r1 + r2);
    var hankeiMinus = (r1 - r2) * (r1 - r2);

    if (hankei >= chuushinKyori && hankeiMinus <= chuushinKyori)
    {
        resultList.Add("Yes");
    }
    else
    {
        resultList.Add("No");
    }

}

Console.WriteLine(string.Join("\n", resultList));
