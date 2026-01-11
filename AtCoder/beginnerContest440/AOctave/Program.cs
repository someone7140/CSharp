var xy = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var x = xy[0];
var y = xy[1];

Console.WriteLine(x * Math.Pow(2, y));
