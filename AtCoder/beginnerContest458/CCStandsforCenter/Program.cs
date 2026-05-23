var sList = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();
var sCount = sList.Count;

var result = 0L;
for (var i = 0; i < sCount; i++)
{
    var s = sList[i];
    if (s == "C")
    {
        var mae = i;
        var ushiro = sCount - i - 1;
        var min = mae < ushiro ? mae : ushiro;

        result += min + 1;
    }
}

Console.WriteLine(result);
