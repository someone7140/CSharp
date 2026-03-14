var hwq = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var h = hwq[0];
var w = hwq[1];
var q = hwq[2];

var resultList = new List<string>();

for (var i = 0; i < q; i++)
{
    var queries = Console.ReadLine().Split(" ");
    if (queries[0] == "1")
    {
        var gyou = int.Parse(queries[1]);
        resultList.Add((gyou * w).ToString());
        h -= gyou;
    }
    else
    {
        var retsu = int.Parse(queries[1]);
        resultList.Add((retsu * h).ToString());
        w -= retsu;
    }
}

Console.WriteLine(string.Join("\n", resultList));
