var n = int.Parse(Console.ReadLine());
var aList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

var resultList = new string[n];

for (var i = 0; i < n; i++)
{
    if (resultList[i] != null)
    {
        continue;
    }

    var endNumberString = "";
    var hashSet = new HashSet<int>();
    var nextIndex = i;
    while (endNumberString == "")
    {
        hashSet.Add(nextIndex);
        var nextIndex2 = aList[nextIndex] - 1;
        if (nextIndex == nextIndex2)
        {
            endNumberString = (nextIndex2 + 1).ToString();
            break;
        }
        else
        {
            nextIndex = nextIndex2;
        }
    }

    foreach (var j in hashSet)
    {
        resultList[j] = endNumberString;
    }
}

Console.WriteLine(string.Join(" ", resultList));