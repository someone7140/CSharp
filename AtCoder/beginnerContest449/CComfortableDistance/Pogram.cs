var nlr = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nlr[0];
var l = nlr[1];
var r = nlr[2];

var sList = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();
var sDict = new Dictionary<string, List<int>>();

for (var i = 0; i < n; i++)
{
    var s = sList[i];

    if (sDict.ContainsKey(s))
    {
        sDict[s].Add(i);
    }
    else
    {
        sDict[s] = [i];
    }

}

long result = 0;
foreach (var s in sDict)
{
    var indexList = s.Value;
    var indexSize = indexList.Count;
    for (var i = 0; i < indexSize - 1; i++)
    {
        var now = indexList[i];
        var saisyou = now + l;
        var saidai = now + r;
        var saisyouIndex = indexList.BinarySearch(saisyou);
        if (saisyouIndex < 0)
        {
            saisyouIndex = ~saisyouIndex;
        }
        if (saisyouIndex < indexSize)
        {
            var saisyouSabun = indexList[saisyouIndex] - indexList[i];
            if (saisyouSabun <= r)
            {
                var saidaiIndex = indexList.BinarySearch(saidai);
                var plusOneFlag = true;
                if (saidaiIndex < 0)
                {
                    saidaiIndex = ~saidaiIndex;
                    plusOneFlag = false;
                }

                if (saidaiIndex == indexSize)
                {
                    result += indexSize - saisyouIndex;
                }
                else
                {
                    result += saidaiIndex - saisyouIndex;
                    if (plusOneFlag)
                    {
                        result += 1;
                    }
                }
            }
        }
    }
}


Console.WriteLine(result);
