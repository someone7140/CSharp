var n = int.Parse(Console.ReadLine());

var cDict = new Dictionary<string, long>();
var cListLst = new List<List<long>>();
for (var i = 0; i < n - 1; i++)
{
    var cList = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
    cListLst.Add(cList);
    var cListLen = cList.Count;
    for (var j = 0; j < cListLen; j++)
    {
        var key1 = j.ToString() + "-" + (j + i + 1).ToString();
        var key2 = (j + i + 1).ToString() + "-" + j.ToString();
        cDict[key1] = cList[j];
        cDict[key2] = cList[j];
    }
}

var result = "No";
for (var i = 0; i < n - 1; i++)
{
    var cList = cListLst[i];
    var cListLen = cList.Count;

    for (var j = 0; j < cListLen; j++)
    {
        var c1 = cList[j];
        for (var k = 0; k < cListLen; k++)
        {
            if (j != k && k + 1 != i)
            {
                var c2 = cList[k];
                var c3 = cDict[(k + 1).ToString() + "-" + (j + 1).ToString()];
                if (c1 > (c2 + c3))
                {
                    result = "Yes";
                    break;
                }
            }

        }
    }
}

Console.WriteLine(result);
