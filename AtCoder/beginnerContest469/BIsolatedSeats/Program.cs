var n = int.Parse(Console.ReadLine());
var sList = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();

var result = 0;

for (var i = 0; i < n; i++)
{
    if (n == 1)
    {
        if (sList[i] == "x")
        {
            result++;
        }
    }
    else if (i == 0)
    {
        if (sList[i] == "x" && sList[i + 1] == "x")
        {
            result++;
        }
    }
    else if (i == n - 1)
    {
        if (sList[i] == "x" && sList[i - 1] == "x")
        {
            result++;
        }
    }
    else
    {
        if (sList[i] == "x" && sList[i - 1] == "x" && sList[i + 1] == "x")
        {
            result++;
        }
    }
}

Console.WriteLine(result);
