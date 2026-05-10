var sStrings = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();
var sCount = sStrings.Count;

var result = 0L;
var bunbo = 998244353L;
var sDict = new Dictionary<string, long>();

for (var i = 0; i < sCount; i++)
{
    var tempCount = 1L;
    foreach (var sElem in sDict)
    {
        if (sElem.Key != sStrings[i])
        {
            tempCount = (tempCount + sElem.Value) % bunbo;
        }
    }

    if (!sDict.ContainsKey(sStrings[i]))
    {
        sDict[sStrings[i]] = tempCount % bunbo;
    }
    else
    {
        sDict[sStrings[i]] = (sDict[sStrings[i]] + tempCount) % bunbo;
    }

    result = (result + tempCount) % bunbo;
}

Console.WriteLine(result);
