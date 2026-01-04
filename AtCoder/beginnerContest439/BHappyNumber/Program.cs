var nStrList = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();

var before = -1;
var result = "Yes";
var hashSet = new HashSet<int>();

var target = nStrList;

while (true)
{
    var total = 0;
    foreach (string nStr in target)
    {
        var n = int.Parse(nStr);
        total += (int)Math.Pow(n, 2);
    }
    if (total == 1)
    {
        break;
    }
    if (hashSet.Contains(total))
    {
        result = "No";
        break;
    }
    hashSet.Add(total);
    target = total.ToString().ToCharArray().Select(c => c.ToString()).ToList();
}

Console.WriteLine(result);
