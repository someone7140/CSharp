var ab = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var a = ab[0];
var b = ab[1];

var tempA = a * 3;
var tempB = b * 2;

if (tempA > tempB)
{
    Console.WriteLine("Yes");
}
else
{
    Console.WriteLine("No");
}
