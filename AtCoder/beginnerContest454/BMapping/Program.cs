var nm = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nm[0];
var m = nm[1];

var fList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var fSet = fList.ToHashSet();

Console.WriteLine(fList.Count == fSet.Count ? "Yes" : "No");

var result2 = "Yes";

for (var i = 1; i <= m; i++)
{
    if (!fSet.Contains(i))
    {
        result2 = "No";
        break;
    }
}

Console.WriteLine(result2);
