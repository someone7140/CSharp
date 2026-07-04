var xy = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var x = xy[0];
var y = xy[1];

var gcdVal = Gcd(x, y);

if (x / gcdVal == 16 && y / gcdVal == 9)
{
    Console.WriteLine("Yes");
}
else
{
    Console.WriteLine("No");
}

static int Gcd(int a, int b)
{
    if (a < b)
        // 引数を入替えて自分を呼び出す
        return Gcd(b, a);
    while (b != 0)
    {
        var remainder = a % b;
        a = b;
        b = remainder;
    }
    return a;
}