var n = int.Parse(Console.ReadLine());

var resultList = new List<string>();
for (var i = n; i > 0; i--)
{
    resultList.Add(i.ToString());
}

Console.WriteLine(string.Join(",", resultList));
