var x = int.Parse(Console.ReadLine());
var q = int.Parse(Console.ReadLine());

var abList = new List<int?>();
var addList = new List<List<int>>();
var countDict = new Dictionary<int, int>();

for (var i = 0; i < q; i++)
{
    var ab = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var a = ab[0];
    var b = ab[1];

    addList.Add(ab);

    if (!countDict.ContainsKey(a))
    {
        countDict[a] = 1;
    }
    else
    {
        countDict[a] += 1;
    }

    if (!countDict.ContainsKey(b))
    {
        countDict[b] = 1;
    }
    else
    {
        countDict[b] += 1;
    }

    abList.Add(a);
    abList.Add(b);
}

abList.Sort();

var resultList = new List<int>();
var nowIndex = q;
resultList.Add(abList[q]);

for (var i = q - 1; i > 0; i--)
{
    var ab = addList[i];
    var a = ab[0];
    var b = ab[1];

    var now = abList[nowIndex];
    var changeIndex = 0;

    if (now > a)
    {
        changeIndex++;
    }
    if (now <= a)
    {
        changeIndex--;
    }

    if (now > b)
    {
        changeIndex++;
    }
    if (now <= b)
    {
        changeIndex--;
    }

    countDict[a] = countDict[a] - 1;
    countDict[b] = countDict[b] - 1;

    if (changeIndex > 0)
    {
        var plus = 1;
        var tempCount = 0;
        while (changeIndex > 0)
        {

        }
    }



}

var resultListString = new List<string>();
for (var i = q - 1; i >= 0; i--)
{
    resultListString.Add(int.Parse(resultList[i]));
}

Console.WriteLine(string.Join("\n", resultListString));
