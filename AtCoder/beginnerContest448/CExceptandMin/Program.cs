var nq = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nq[0];
var q = nq[1];
var aStrList = Console.ReadLine().Split(" ").ToList();

var aList = new List<Ball>();
for (var i = 0; i < n; i++)
{
    aList.Add(new Ball
    {
        Index = i,
        BallNumber = int.Parse(aStrList[i]),
    });
}

var aListSorted = aList.OrderBy(x => x.BallNumber).ToList();

var resultList = new List<string>();

for (var i = 0; i < q; i++)
{
    var minSortedIndex = 0;
    var k = int.Parse(Console.ReadLine());
    var bList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var deletedIndexSet = new HashSet<int>();
    foreach (var b in bList)
    {
        var bIndex = b - 1;
        var ballVal = aList[bIndex];
        if (aListSorted[minSortedIndex].BallNumber == ballVal.BallNumber)
        {
            while (true)
            {
                minSortedIndex++;
                if (!deletedIndexSet.Contains(aListSorted[minSortedIndex].Index))
                {
                    break;
                }
            }
        }
        deletedIndexSet.Add(bIndex);
    }
    resultList.Add(aListSorted[minSortedIndex].BallNumber.ToString());
}

Console.WriteLine(string.Join("\n", resultList));

class Ball
{
    public required int Index { get; set; }

    public required int BallNumber { get; set; }
}
