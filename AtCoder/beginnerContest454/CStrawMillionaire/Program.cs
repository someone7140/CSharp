var nm = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nm[0];
var m = nm[1];

var abDict = new Dictionary<int, List<int>>();
for (var i = 0; i < m; i++)
{
    var ab = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var a = ab[0];
    var b = ab[1];

    if (!abDict.ContainsKey(a))
    {
        abDict[a] = [b];
    }
    else
    {
        abDict[a].Add(b);
    }
}

var resultSet = new HashSet<int>();
loop(1);

Console.WriteLine(resultSet.Count);

void loop(int nowItem)
{
    if (!resultSet.Contains(nowItem))
    {
        resultSet.Add(nowItem);
        if (abDict.ContainsKey(nowItem))
        {
            var itemList = abDict[nowItem];
            foreach (var toItem in itemList)
            {
                if (!resultSet.Contains(toItem))
                {
                    loop(toItem);
                }
            }
        }
    }
}
