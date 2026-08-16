var t = int.Parse(Console.ReadLine());
var resultList = new List<string>();

// ユークリッドの互除法 
static long Gcd(long a, long b)
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

for (var i = 0; i < t; i++)
{
    var pqrs = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
    var px = pqrs[0];
    var py = pqrs[1];
    var qx = pqrs[2];
    var qy = pqrs[3];
    var rx = pqrs[4];
    var ry = pqrs[5];
    var sx = pqrs[6];
    var sy = pqrs[7];

    // C1の傾き
    var c1YSabun = py - qy;
    var c1XSabun = px - qx;
    var gcd1 = Gcd(Math.Abs(c1YSabun), Math.Abs(c1XSabun));
    c1YSabun = c1YSabun / gcd1;
    c1XSabun = c1XSabun / gcd1;

    // C2の傾き
    var c2YSabun = ry - sy;
    var c2XSabun = rx - sx;
    var gcd2 = Gcd(Math.Abs(c2YSabun), Math.Abs(c2XSabun));
    c2YSabun = c2YSabun / gcd2;
    c2XSabun = c2XSabun / gcd2;

    if (c1YSabun == c2YSabun && c1XSabun == c2XSabun)
    {
        resultList.Add("No");
    }
    else
    {
        resultList.Add("Yes");
    }
}


Console.WriteLine(string.Join("\n", resultList));
