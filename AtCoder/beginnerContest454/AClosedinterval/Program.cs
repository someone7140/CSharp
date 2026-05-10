var lr = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var l = lr[0];
var r = lr[1];

Console.WriteLine(r - l + 1);
