var n = int.Parse(Console.ReadLine());
var xList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var result = "Yes";

foreach (var x in xList)
{
    if (x >= 0)
    {
        result = "No";
        break;
    }
}

Console.WriteLine(result);
