var nm = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nm[0];
var m = nm[1];

var aList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var bList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var numberCountList = new List<NumberCount>();

for (var i = 0; i < n; i++)
{
    if (i == 0)
    {
        numberCountList.Add(new NumberCount
        {
            Value = aList[i],
            Count = 0,
        });
        numberCountList.Add(new NumberCount
        {
            Value = aList[i] + 1,
            Count = 1,
        });
    }
    else
    {
        var a = aList[i];
        var aPlus1 = aList[i] + 1;
        var tempNumberCountList = new List<NumberCount>();

        foreach (var numberCount in numberCountList)
        {
            var tempVal = a + numberCount.Value;
            if (tempVal % 2 == bList[i - 1])
            {
                tempNumberCountList.Add(new NumberCount
                {
                    Value = a,
                    Count = numberCount.Count,
                });
            }

            var tempVal2 = aPlus1 + numberCount.Value;
            if (tempVal2 % 2 == bList[i - 1])
            {
                tempNumberCountList.Add(new NumberCount
                {
                    Value = aPlus1,
                    Count = numberCount.Count + 1,
                });
            }
        }

        numberCountList = tempNumberCountList;
    }
}

var result = -1;

foreach (var numberCount in numberCountList)
{
    if (result == -1 || result > numberCount.Count)
    {
        result = numberCount.Count;
    }
}
Console.WriteLine(result);

class NumberCount
{
    public required int Value { get; set; }
    public required int Count { get; set; }

}
