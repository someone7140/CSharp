var nm = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nm[0];
var m = nm[1];

var result = 0;
var x = m;

while (x != 0)
{
    result++;
    x = n % x;

}

Console.WriteLine(result);
