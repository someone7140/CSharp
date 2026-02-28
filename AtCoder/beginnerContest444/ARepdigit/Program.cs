var nStrings = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();

if (nStrings[0] == nStrings[1] && nStrings[0] == nStrings[2] && nStrings[1] == nStrings[2])
{
    Console.WriteLine("Yes");
}
else
{
    Console.WriteLine("No");
}