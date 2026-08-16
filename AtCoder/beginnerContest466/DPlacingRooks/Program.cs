var nm = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nm[0];
var m = nm[1];

var komaRowKeyDict = new Dictionary<int, HashSet<int>>();
var komaColumnKeyDict = new Dictionary<int, HashSet<int>>();

for (var i = 0; i < m; i++)
{
    var rc = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var r = rc[0];
    var c = rc[1];

    komaRowKeyDict.Remove(r);
    komaColumnKeyDict.Remove(c);

    if (komaRowKeyDict.TryGetValue(r, out var rValues))
    {
        rValues.Add(c);
    }
    else
    {
        komaRowKeyDict[r] = [c];
    }

    if (komaColumnKeyDict.TryGetValue(c, out var cValues))
    {
        cValues.Add(r);
    }
    else
    {
        komaColumnKeyDict[c] = [r];
    }
}

var result = 0L;
foreach (var komaRowElem in komaRowKeyDict)
{
    var r = komaRowElem.Key;
    foreach (var c in komaRowElem.Value)
    {
        if (komaColumnKeyDict.TryGetValue(c, out var values))
        {
            if (values.Contains(r))
            {
                result++;
            }
        }
    }

}

Console.WriteLine(result);
