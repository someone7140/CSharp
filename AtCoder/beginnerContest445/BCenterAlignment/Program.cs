var n = int.Parse(Console.ReadLine());
var maxLen = -1;

var sList = new List<string>();

for (var i = 0; i < n; i++)
{
    var s = Console.ReadLine();
    var sLen = s.Length;
    sList.Add(s);
    if (sLen > maxLen)
    {
        maxLen = sLen;
    }
}

var resultList = new List<string>();

for (var i = 0; i < n; i++)
{
    var s = sList[i];
    var sLen = s.Length;

    var plusString = "";
    for (var j = 0; j < (maxLen - sLen) / 2; j++)
    {
        plusString += ".";
    }

    resultList.Add(plusString + s + plusString);
}

Console.WriteLine(string.Join("\n", resultList));
