var n = int.Parse(Console.ReadLine());

var aListList = new List<List<int>>();
for (var i = 0; i < n; i++)
{
    var aList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    aList.RemoveAt(0);
    aListList.Add(aList);
}

var xy = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var x = xy[0];
var y = xy[1];


Console.WriteLine(aListList[x - 1][y - 1]);
