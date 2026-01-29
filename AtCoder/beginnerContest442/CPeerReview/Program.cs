var nm = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nm[0];
var m = nm[1];

var abDict = new Dictionary<int, HashSet<int>>();

for (var i = 0; i < m; i++)
{
    var ab = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var a = ab[0];
    var b = ab[1];

    if (abDict.ContainsKey(a))
    {
        abDict[a].Add(b);
    }
    else
    {
        abDict[a] = [b];
    }

    if (abDict.ContainsKey(b))
    {
        abDict[b].Add(a);
    }
    else
    {
        abDict[b] = [a];
    }
}

static long nCk(long n, long k)
{
    if (n < k) return 0;
    if (n == k) return 1;

    long x = 1;
    for (long i = 0; i < k; i++)
    {
        x = x * (n - i) / (i + 1);
    }
    return x;
}

var resultList = new List<string>();
for (var i = 1; i <= n; i++)
{
    var sadokuCount = n - 1;
    if (abDict.ContainsKey(i))
    {
        sadokuCount -= abDict[i].Count;
    }
    if (sadokuCount >= 3)
    {
        var result = nCk(sadokuCount, 3);
        resultList.Add(result.ToString());
    }
    else
    {
        resultList.Add("0");
    }
}

Console.WriteLine(string.Join(" ", resultList));
