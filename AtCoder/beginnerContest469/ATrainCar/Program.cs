var nk = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nk[0];
var k = nk[1];

Console.WriteLine(n - k + 1);
