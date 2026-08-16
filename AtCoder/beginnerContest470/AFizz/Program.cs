var n = int.Parse(Console.ReadLine());
var resultList = new List<string>();

for (var i = 1; i <= n; i++)
{
    if (i % 3 == 0)
    {
        resultList.Add("Fizz");
    }
    else
    {
        resultList.Add(i.ToString());
    }
}

Console.WriteLine(string.Join("\n", resultList));
