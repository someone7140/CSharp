var nq = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nq[0];
var q = nq[1];

var resultList = new List<string>();
var countMasuDict = new Dictionary<int, HashSet<int>>();
var masuCountDict = new Dictionary<int, int>();
var countSortedList = new SortedList<int, int>();
var allMinus = 0;

for (var i = 0; i < q; i++)
{
    var query = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var q1 = query[0];
    var q2 = query[1];

    if (q1 == 1)
    {
        if (!masuCountDict.ContainsKey(q2))
        {
            masuCountDict[q2] = 1;
            if (!countMasuDict.ContainsKey(1))
            {
                countMasuDict[1] = new HashSet<int>(q2);
                countSortedList.Add(1, 1);
            }
            else
            {
                countMasuDict[1].Add(q2);
                countSortedList[1] = countSortedList[1] + 1;
            }
        }
        else
        {
            var nowCount = masuCountDict[q2];
            masuCountDict[q2] = nowCount + 1;

            countMasuDict[nowCount].Remove(q2);
            countSortedList[nowCount] = countSortedList[nowCount] - 1;
            if (countMasuDict[nowCount].Count == 0)
            {
                countMasuDict.Remove(nowCount);
                countSortedList.Remove(nowCount);
            }
            if (!countMasuDict.ContainsKey(nowCount + 1))
            {
                countMasuDict[nowCount + 1] = new HashSet<int>(q2);
                countSortedList.Add(nowCount + 1, 1);
            }
            else
            {
                countMasuDict[nowCount + 1].Add(q2);
                countSortedList[nowCount + 1] = countSortedList[nowCount + 1] + 1;
            }
        }

    }
    else
    {
        var tempResult = -allMinus;
        var listCount = countSortedList.Count;
        var countValueList = countSortedList.Values;
        var targetIndex = countSortedList.IndexOfKey(q2);
        for (var j = targetIndex; j < listCount; j++)
        {
            tempResult += countValueList[j];
        }
        resultList.Add(tempResult.ToString());
    }

}

Console.WriteLine(string.Join("\n", resultList));
