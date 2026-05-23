var s = Console.ReadLine();
var x = int.Parse(Console.ReadLine());

var s1 = s[x..];
var s2 = s1[..^x];

Console.WriteLine(s2);
