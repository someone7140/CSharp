var pq = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var p = pq[0];
var q = pq[1];

var xy = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var x = xy[0];
var y = xy[1];

var result = "Yes";
if (p <= x && p + 99 >= x)
{
    if (q <= y && q + 99 >= y)
    {
        result = "Yes";
    }
    else
    {
        result = "No";
    }
}
else
{
    result = "No";
}

Console.WriteLine(result);
