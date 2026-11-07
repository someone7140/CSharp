var n = int.Parse(Console.ReadLine());
var aList = Console.ReadLine().Split(" ").Select(long.Parse).ToList();

var aDpListList = new List<List<MaxMin>>();

for (var i = 0; i < n; i++)
{
    if (i == 0)
    {
        var aDpList = new List<MaxMin>();
        if (aList[i] < 0)
        {
            aDpList.Add(new MaxMin
            {
                Max = 0,
                Min = aList[i],
                Now = aList[i],
            });

            aDpList.Add(new MaxMin
            {
                Max = aList[i] * -1,
                Min = 0,
                Now = aList[i] * -1,
            });
        }
        else
        {
            aDpList.Add(new MaxMin
            {
                Max = aList[i],
                Min = 0,
                Now = aList[i],
            });

            aDpList.Add(new MaxMin
            {
                Max = 0,
                Min = aList[i] * -1,
                Now = aList[i] * -1,
            });
        }

        aDpListList.Add(aDpList);
    }
    else
    {
        var before = aDpListList[i - 1];
        // 変えない場合
        var newNow = before[0].Now + aList[i];
        var maxMinNotChange = new MaxMin
        {
            Max = before[0].Max < newNow ? newNow : before[0].Max,
            Min = before[0].Min > newNow ? newNow : before[0].Min,
            Now = newNow,
        };
        // すでに変えてる場合
        newNow = before[1].Now + aList[i];
        var maxMinChange1 = new MaxMin
        {
            Max = before[1].Max < newNow ? newNow : before[1].Max,
            Min = before[1].Min > newNow ? newNow : before[1].Min,
            Now = newNow,
        };
        // 今回変える場合
        newNow = before[0].Now - aList[i];
        var maxMinChange2 = new MaxMin
        {
            Max = before[0].Max < newNow ? newNow : before[0].Max,
            Min = before[0].Min > newNow ? newNow : before[0].Min,
            Now = newNow,
        };
        var maxMinChange1Sum = maxMinChange1.Max - maxMinChange1.Min;
        var maxMinChange2Sum = maxMinChange2.Max - maxMinChange2.Min;

        var aDpList = new List<MaxMin>();
        if (maxMinChange1Sum > maxMinChange2Sum)
        {
            aDpList.Add(maxMinNotChange);
            aDpList.Add(maxMinChange1);
        }
        else
        {
            aDpList.Add(maxMinNotChange);
            aDpList.Add(maxMinChange2);
        }

        aDpListList.Add(aDpList);
    }
}

var lastChange1Sum = aDpListList[n - 1][0].Max - aDpListList[n - 1][0].Min + 1;
var lastChhange2Sum = aDpListList[n - 1][1].Max - aDpListList[n - 1][1].Min + 1;
if (lastChange1Sum > lastChhange2Sum)
{
    Console.WriteLine(lastChange1Sum);
}
else
{
    Console.WriteLine(lastChhange2Sum);
}

class MaxMin
{
    public required long Max { get; set; }

    public required long Min { get; set; }
    public required long Now { get; set; }
}