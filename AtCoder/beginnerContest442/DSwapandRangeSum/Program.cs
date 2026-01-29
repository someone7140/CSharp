var nq = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nq[0];
var q = nq[1];
var aList = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
var aSumArray = new long[n];
var changeArray = new int[n];
var changeSortedSet = new SortedSet<int>();
var resultList = new List<string>();

for (var i = 0; i < n; i++)
{
    if (i == 0)
    {
        aSumArray[i] = aList[i];
    }
    else
    {
        aSumArray[i] = aList[i] + aSumArray[i - 1];
    }
    changeArray[i] = -1;
}

for (var i = 0; i < q; i++)
{
    var qList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    if (qList[0] == 1)
    {
        var irekaeIndex = qList[1] - 1;
        var irekaeIndexPlusOne = irekaeIndex + 1;
        var ireale1 = aList[irekaeIndex];
        var ireale2 = aList[irekaeIndexPlusOne];
        aSumArray[irekaeIndex] = aSumArray[irekaeIndex] - ireale1 + ireale2;
        aList[irekaeIndex] = ireale2;
        aList[irekaeIndexPlusOne] = ireale1;
    }
    else
    {
        var startIndex = qList[1] - 1;
        var endIndex = qList[2] - 1;

        if (startIndex == endIndex)
        {
            resultList.Add(aList[startIndex].ToString());
        }
        else if (startIndex == 0)
        {
            resultList.Add(aSumArray[endIndex].ToString());
        }
        else
        {
            resultList.Add((aSumArray[endIndex] - aSumArray[startIndex - 1]).ToString());
        }
    }
}

Console.WriteLine(string.Join("\n", resultList));
