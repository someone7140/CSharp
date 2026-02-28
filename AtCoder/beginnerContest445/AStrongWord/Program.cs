var sStrings = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();

if (sStrings[0] == sStrings[sStrings.Count - 1])
{
    Console.WriteLine("Yes");
}
else
{
    Console.WriteLine("No");
}
