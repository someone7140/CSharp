var sArray = Console.ReadLine().Split("-").Select(int.Parse).ToList();
var s1 = sArray[0];
var s2 = sArray[1];

if (s2 == 8)
{
    Console.WriteLine((s1 + 1) + "-1");
}
else
{
    Console.WriteLine(s1 + "-" + (s2 + 1));
}

