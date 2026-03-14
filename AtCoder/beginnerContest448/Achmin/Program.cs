var nx = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nx[0];
var x = nx[1];
var aList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

var limit = x;
var resultList = new List<string>();
for (var i = 0; i < n; i++)
{
    if (limit > aList[i])
    {
        limit = aList[i];
        resultList.Add("1");
    }
    else
    {
        resultList.Add("0");
    }
}

Console.WriteLine(string.Join("\n", resultList));
