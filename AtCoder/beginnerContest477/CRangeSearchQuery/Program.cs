var q = int.Parse(Console.ReadLine());
var sList = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();
var t = Console.ReadLine();

var sTemp = "";
var sTempLen = 0;
var sLen = sList.Count;
var tLen = t.Length;
var icchiIndexList = new List<int>();

for (var i = 0; i < sLen; i++)
{
    if (sTempLen == tLen)
    {
        sTemp = sTemp.Substring(1);
        sTemp += sList[i];
    }
    else
    {
        sTemp += sList[i];
        sTempLen++;
    }

    if (sTemp == t)
    {
        icchiIndexList.Add(i - tLen + 2);
    }
}

var resultList = new List<string>();
var icchiIndexListCount = icchiIndexList.Count;

for (var i = 0; i < q; i++)
{
    var lr = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var l = lr[0];
    var r = lr[1];

    if (icchiIndexListCount == 0)
    {
        resultList.Add("No");
        continue;
    }

    var lrLen = r - l + 1;

    if (lrLen < tLen)
    {
        resultList.Add("No");
        continue;
    }

    var icchiIndexIndex = icchiIndexList.BinarySearch(l);
    if (icchiIndexIndex < 0)
    {
        var icchiIndexIndexUpper = ~icchiIndexIndex;
        if (icchiIndexIndexUpper == icchiIndexListCount)
        {
            resultList.Add("No");
        }
        else
        {
            var icchiIndexUpper = icchiIndexList[icchiIndexIndexUpper];
            var target = icchiIndexUpper + tLen - 1;
            if (target <= r)
            {
                resultList.Add("Yes");
            }
            else
            {
                resultList.Add("No");
            }
        }
    }
    else
    {
        resultList.Add("Yes");
    }

}

Console.WriteLine(string.Join("\n", resultList));
