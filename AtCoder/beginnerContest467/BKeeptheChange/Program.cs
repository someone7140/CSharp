var n = int.Parse(Console.ReadLine());

var result = 0;
for (var i = 0; i < n; i++)
{
    var abs = Console.ReadLine().Split(" ").ToList();
    var a = int.Parse(abs[0]);
    var b = int.Parse(abs[1]);
    var s = abs[2];

    if (s == "keep")
    {
        result += b - a;
    }
}

Console.WriteLine(result);
