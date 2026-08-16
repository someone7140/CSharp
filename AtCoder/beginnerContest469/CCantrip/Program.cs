var n = int.Parse(Console.ReadLine());
var sList = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();

var resultList = new List<string>();
var motteruMaru = 0;
var zanMaru = 0;
var tempResult = n;
var befreSabun = 0;

for (var i = 0; i < n; i++)
{
    if (i < n - 1 && sList[i] == "o")
    {
        motteruMaru++;
    }
}

for (var i = n - 1; i >= 0; i--)
{
    if (i == n - 1)
    {
        resultList.Add(tempResult.ToString());
        continue;
    }

    var zan = n - (i + 1);
    var sabun = motteruMaru - (zan - zanMaru);
    var update = sabun - befreSabun;
    if (update < 0)
    {
        tempResult += update;
        befreSabun = sabun;
    }
    resultList.Add(tempResult.ToString());
    if (sList[i] == "o")
    {
        zanMaru++;
        motteruMaru--;
    }
}

resultList.Reverse();
Console.WriteLine(string.Join("\n", resultList));
