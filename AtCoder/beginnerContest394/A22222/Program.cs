var sArray = Console.ReadLine()?.Where(s => s.Equals('2')).ToArray();
var result = string.Join("", sArray);
Console.WriteLine(result);