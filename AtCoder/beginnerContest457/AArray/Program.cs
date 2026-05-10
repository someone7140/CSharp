var n = int.Parse(Console.ReadLine());
var aList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var x = int.Parse(Console.ReadLine());

Console.WriteLine(aList[x - 1]);
