var s = Console.ReadLine();
var t = Console.ReadLine();

var sDeletedA = s.Replace("A", "");
var tDeletedA = t.Replace("A", "");

if (sDeletedA != tDeletedA)
{
    Console.WriteLine(-1);
    return;
}

var sList = s.ToCharArray().Select(c => c.ToString()).ToList();
var sLen = sList.Count;
var tList = t.ToCharArray().Select(c => c.ToString()).ToList();
var tLen = tList.Count;
var nowSIndex = 0;
var nowTIndex = 0;

var result = 0;
while (nowSIndex < sLen || nowTIndex < tLen)
{
    if (nowSIndex == sLen)
    {
        result++;
        nowTIndex++;
    }
    else if (nowTIndex == tLen)
    {
        result++;
        nowSIndex++;
    }
    else
    {
        if (sList[nowSIndex] == tList[nowTIndex])
        {
            nowSIndex++;
            nowTIndex++;
        }
        else if (sList[nowSIndex] == "A")
        {
            nowSIndex++;
            result++;
        }
        else if (tList[nowTIndex] == "A")
        {
            nowTIndex++;
            result++;
        }

    }
}

Console.WriteLine(result);
