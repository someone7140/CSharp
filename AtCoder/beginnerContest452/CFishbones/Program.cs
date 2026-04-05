var n = int.Parse(Console.ReadLine());
var kotsuzuiList = new List<Kotsuzui>();
var aDict = new Dictionary<int, List<Kotsuzui>>();
for (var i = 0; i < n; i++)
{
    var ab = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var a = ab[0];
    var b = ab[1];

    var kotsuzui = new Kotsuzui
    {
        A = a,
        B = b - 1,
        Index = i
    };
    kotsuzuiList.Add(kotsuzui);
    if (!aDict.ContainsKey(a))
    {
        aDict[a] = [kotsuzui];
    }
    else
    {
        aDict[a].Add(kotsuzui);
    }
}

var m = int.Parse(Console.ReadLine());
var rokkotsuList = new List<Rokkotsu>();
var rokkotsuIndexSet = new HashSet<string>();
for (var i = 0; i < m; i++)
{
    var s = Console.ReadLine();
    var sList = s.ToCharArray().Select(c => c.ToString()).ToList();
    var sLen = sList.Count;

    var rokkotsu = new Rokkotsu
    {
        Moji = s,
        MojiList = sList,
        Index = i
    };
    rokkotsuList.Add(rokkotsu);
    if (aDict.ContainsKey(sLen))
    {
        var positionSet = aDict[sLen].Select(a => a.B).ToHashSet();
        foreach (int position in positionSet)
        {
            var key = sLen.ToString() + "-" + position.ToString() + "-" + sList[position];
            rokkotsuIndexSet.Add(key);
        }
    }
}

var resultList = new List<string>();
for (var i = 0; i < m; i++)
{
    var rokkotsu = rokkotsuList[i];
    var mojiLen = rokkotsu.MojiList.Count;
    if (mojiLen == n)
    {
        var result = "Yes";
        for (var j = 0; j < mojiLen; j++)
        {
            var kotsuzui = kotsuzuiList[j];
            var key = kotsuzui.A.ToString() + "-" + kotsuzui.B.ToString() + "-" + rokkotsu.MojiList[j];
            if (!rokkotsuIndexSet.Contains(key))
            {
                result = "No";
                break;
            }
        }
        resultList.Add(result);
    }
    else
    {
        resultList.Add("No");
    }
}

Console.WriteLine(string.Join("\n", resultList));

class Kotsuzui
{
    public required int A { get; set; }

    public required int B { get; set; }

    public required int Index { get; set; }
}

class Rokkotsu
{
    public required string Moji { get; set; }

    public required List<string> MojiList { get; set; }

    public required int Index { get; set; }
}


