var t = int.Parse(Console.ReadLine());
var resultList = new List<string>();

for (var i = 0; i < t; i++)
{
    var tArray = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
    var minAC = Math.Min(tArray[0], tArray[2]);
    var sum = tArray[0] + tArray[1] + tArray[2];
    var wari3 = sum / 3;
    var half = max / 2;
    var start = 0L;
    var loopFlag = true;
    if (minAC > 0 && sum / minAC == 3 && sum % minAC == 0)
    {
        half = minAC;
    }
    else
    {
        while (loopFlag)
        {
            loopFlag = max > start && half > start && half < max;
            if (half > minAC)
            {
                max = half;
                half = (max + start) / 2L;
                continue;
            }

            var zan = tArray[0] + tArray[1] + tArray[2] - half * 2;
            start = half;
            half = (max + start) / 2L;
        }
    }

    resultList.Add(half.ToString());
}

Console.WriteLine(string.Join("\n", resultList));
