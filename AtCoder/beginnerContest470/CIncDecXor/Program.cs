var nq = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nq[0];
var q = nq[1];

var valList = new int[n].ToList();
var indexValDict = new Dictionary<int, int>();

var resultList = new List<string>();
var tempResult = 0;
var startVal = 0;

for (var i = 0; i < q; i++)
{
    var queries = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var kubun = queries[0];
    if (kubun == 1)
    {
        var index = queries[1] - 1;
        var before = 0;
        var after = 0;
        if (indexValDict.TryGetValue(index, out var val1))
        {
            before = indexValDict[index];
            indexValDict[index]++;
            after = indexValDict[index];

        }
        else
        {
            before = 0;
            indexValDict[index] = 1;
            after = 1;
        }

        tempResult ^= before;
        tempResult ^= after;

        resultList.Add(tempResult.ToString());
    }
    else
    {
        var tempResult2 = 0;
        var indexValDict2 = new Dictionary<int, int>();
        foreach (var elem in indexValDict)
        {
            var newVal = elem.Value - 1;
            if (newVal > 0)
            {
                indexValDict2[elem.Key] = newVal;
                tempResult2 ^= newVal;
            }
        }
        indexValDict = indexValDict2;
        tempResult = tempResult2;
        resultList.Add(tempResult.ToString());
    }
}

Console.WriteLine(string.Join("\n", resultList));
