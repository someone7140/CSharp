var nm = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nm[0];
var m = nm[1];

var countArray1 = new int[m];
var countArray2 = new int[m];
for (var i = 0; i < n; i++)
{
    var ab = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var a = ab[0] - 1;
    var b = ab[1] - 1;
    countArray1[a] += 1;
    countArray2[b] += 1;
}

var resultList = new List<string>();
for (var i = 0; i < m; i++)
{
    var sabun = countArray2[i] - countArray1[i];
    resultList.Add(sabun.ToString());
}

Console.WriteLine(string.Join("\n", resultList));
