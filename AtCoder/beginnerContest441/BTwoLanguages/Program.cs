var nm = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nm[0];
var m = nm[1];

var sSet = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToHashSet();
var tSet = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToHashSet();
var q = int.Parse(Console.ReadLine());

var resultList = new List<string>();
for (var i = 0; i < q; i++)
{
    var wList = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();
    var takahashiFlag = true;
    var aokiFlag = true;
    foreach (string w in wList)
    {
        if (!sSet.Contains(w))
        {
            takahashiFlag = false;
        }
        if (!tSet.Contains(w))
        {
            aokiFlag = false;
        }
    }

    if (takahashiFlag && aokiFlag)
    {
        resultList.Add("Unknown");
    }
    else if (takahashiFlag)
    {
        resultList.Add("Takahashi");
    }
    else if (aokiFlag)
    {
        resultList.Add("Aoki");
    }
    else
    {
        resultList.Add("Unknown");
    }
}

Console.WriteLine(string.Join("\n", resultList));
