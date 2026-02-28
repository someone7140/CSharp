var nm = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nm[0];
var m = nm[1];

var nHalf = n / 2;
if (n % 2 == 1)
{
    nHalf++;
}

if (nHalf >= m)
{
    Console.WriteLine("Yes");
}
else
{
    Console.WriteLine("No");
}
