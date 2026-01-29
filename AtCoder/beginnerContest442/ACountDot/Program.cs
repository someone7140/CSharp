var sList = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();
var result = 0;
foreach (string s in sList)
{
    if (s == "i" || s == "j")
    {
        result++;
    }
}

Console.WriteLine(result);
