var n = int.Parse(Console.ReadLine());
var cList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

var cArray = new int[n + 1];
var max = 0;

foreach (int c in cList)
{
    cArray[c]++;
    if (cArray[c] > max)
    {
        max = cArray[c];
    }
}

Console.WriteLine(n - max);
