var s = Console.ReadLine();
var sList = s.ToCharArray().Select(c => c.ToString()).ToList();
var sLen = sList.Count;

var result = "";
for (var i = 0; i < sLen; i++)
{
    if (i != 0 && i == sLen - 1)
    {
        result += sList[i];
    }
    else
    {
        result += sList[i] + "o";
    }
}

Console.WriteLine(result);
