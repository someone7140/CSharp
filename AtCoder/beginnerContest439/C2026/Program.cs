var n = int.Parse(Console.ReadLine());

var hashSetOnlyOne = new HashSet<int>();
var hashSetTotal = new HashSet<int>();

for (var y = 3173; y > 1; y--)
{
    for (var x = 1; x < y; x++)
    {
        var total = (y - x) * (y - x);
        total += 2 * y * x;
        if (n >= total)
        {
            if (hashSetTotal.Contains(total))
            {
                hashSetOnlyOne.Remove(total);
            }
            else
            {
                hashSetOnlyOne.Add(total);
                hashSetTotal.Add(total);
            }
        }
    }
}

var resultList = hashSetOnlyOne.ToList();
resultList.Sort();
Console.WriteLine(resultList.Count);
Console.WriteLine(string.Join(" ", resultList));
