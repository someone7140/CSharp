var nm = Console.ReadLine().Split(" ").ToList();
var n = int.Parse(nm[0]);
var m = int.Parse(nm[1]);

var cList = new List<Candidate>();

for (var i = 0; i < n; i++)
{
    cList.Add(new Candidate
    {
        No = i,
        Count = 0,
    });

}

var candidateDict = new Dictionary<int, Dictionary<int, int>>();

for (var i = 0; i < m; i++)
{
    var ab = Console.ReadLine().Split(" ").ToList();
    var a = int.Parse(ab[0]) - 1;
    var b = int.Parse(ab[1]) - 1;
    cList[a].Count++;

    if (candidateDict.TryGetValue(a, out var candidateDictVal1))
    {
        if (candidateDictVal1.TryGetValue(b, out var candidateDictVal2))
        {
            candidateDictVal1[b]++;
        }
        else
        {
            candidateDictVal1[b] = 1;
        }
    }
    else
    {
        candidateDict[a] = new Dictionary<int, int>() { { b, 1 } };
    }
}


var cListSorted = cList
            .OrderByDescending(c => c.Count)
            .ThenBy(c => c.No)
            .ToList();

var countCandidateDict = new Dictionary<int, List<int>>();
foreach (var c in cListSorted)
{
    if (countCandidateDict.TryGetValue(c.Count, out var countCandidateVal))
    {
        countCandidateVal.Add(c.No);
    }
    else
    {
        countCandidateDict[c.Count] = [c.No];
    }
}

var resultList = new List<string>();
for (var i = 0; i < n; i++)
{
    // 暫定の最大値
    Candidate maxCandidate;
    if (cListSorted[0].No == i)
    {
        maxCandidate = new Candidate
        {
            No = cListSorted[1].No,
            Count = cListSorted[1].Count,
        };
    }
    else
    {
        maxCandidate = new Candidate
        {
            No = cListSorted[0].No,
            Count = cListSorted[0].Count,
        };
    }


    if (candidateDict.TryGetValue(i, out var candidateDictValI))
    {
        var sabunUpdateDict = new Dictionary<int, int>();
        foreach (var c in candidateDictValI)
        {
            sabunUpdateDict[c.Key] = c.Value + cList[c.Key].Count;
        }

        if (sabunUpdateDict.TryGetValue(maxCandidate.No, out var sabunUpdateDictVal))
        {
            maxCandidate.Count = sabunUpdateDictVal;
        }

        foreach (var c in sabunUpdateDict)
        {
            if (c.Key != maxCandidate.No)
            {
                if (maxCandidate.Count == c.Value && maxCandidate.No > c.Key)
                {
                    maxCandidate = new Candidate
                    {
                        No = c.Key,
                        Count = c.Value,
                    };
                }
                else if (maxCandidate.Count < c.Value)
                {
                    maxCandidate = new Candidate
                    {
                        No = c.Key,
                        Count = c.Value,
                    };
                }
            }
        }
    }

    resultList.Add((maxCandidate.No + 1).ToString());
}

Console.WriteLine(string.Join("\n", resultList));

class Candidate
{
    public required int No { get; set; }

    public required int Count { get; set; }
}