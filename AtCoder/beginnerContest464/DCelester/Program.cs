var t = int.Parse(Console.ReadLine());

var resultList = new List<string>();

for (var i = 0; i < t; i++)
{
    var n = int.Parse(Console.ReadLine());
    var sList = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();
    var xList = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
    var yList = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
    var rsMaxList = new List<RSMax>();

    for (var j = 0; j < n; j++)
    {
        if (j == 0)
        {
            if (sList[0] == "S")
            {
                rsMaxList.Add(new RSMax
                {
                    RMax = -xList[0],
                    SMax = 0
                });
            }
            else
            {
                rsMaxList.Add(new RSMax
                {
                    RMax = 0,
                    SMax = -xList[0],
                });
            }
        }
        else
        {
            var before = rsMaxList[j - 1];
            if (sList[j] == "S")
            {
                // Sのままの場合
                var s1 = before.SMax;
                var s2 = before.RMax + yList[j - 1];
                // Rに変える場合
                var r1 = before.SMax - xList[j];
                var r2 = before.RMax - xList[j];
                rsMaxList.Add(new RSMax
                {
                    SMax = s1 > s2 ? s1 : s2,
                    RMax = r1 > r2 ? r1 : r2,
                });
            }
            else
            {
                // Rのままの場合
                var r1 = before.SMax;
                var r2 = before.RMax;
                // Sに変える場合
                var s1 = before.SMax - xList[j];
                var s2 = before.RMax - xList[j] + yList[j - 1];
                rsMaxList.Add(new RSMax
                {
                    SMax = s1 > s2 ? s1 : s2,
                    RMax = r1 > r2 ? r1 : r2,
                });
            }
        }
    }

    var resultR = rsMaxList[n - 1].RMax;
    var resultS = rsMaxList[n - 1].SMax;

    if (resultR > resultS)
    {
        resultList.Add(resultR.ToString());
    }
    else
    {
        resultList.Add(resultS.ToString());
    }
}

Console.WriteLine(string.Join("\n", resultList));

class RSMax
{
    public required long RMax { get; set; }

    public required long SMax { get; set; }
}

