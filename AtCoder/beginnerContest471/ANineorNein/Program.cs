var ab = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var a = ab[0];
var b = ab[1];

var result = false;

if (a + b == 9)
{
    result = true;
}
else if (a - b == 9)
{
    result = true;
}
else if (a * b == 9)
{
    result = true;
}
else if (a / b == 9 && a % b == 0)
{
    result = true;
}

Console.WriteLine(result ? "Nine" : "Nein");
