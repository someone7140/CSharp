var ad = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var a = ad[0];
var d = ad[1];

if (a <= d)
{
    Console.WriteLine("Yes");
}
else
{
    Console.WriteLine("No");
}
