var n = int.Parse(Console.ReadLine());
var aList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

var startIndex = n / 2;
var result = 0;

for (var i = startIndex; i < n; i++)
{
    result += aList[i];
}

Console.WriteLine(result);
