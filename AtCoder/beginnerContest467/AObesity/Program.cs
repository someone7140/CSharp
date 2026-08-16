var hw = Console.ReadLine().Split(" ").Select(double.Parse).ToList();
var h = hw[0];
var w = hw[1] * 10000;

var bmi = w / (h * h);

if (bmi >= 25)
{
    Console.WriteLine("Yes");
}
else
{
    Console.WriteLine("No");
}
