var n = int.Parse(Console.ReadLine());
var sList = new List<string>();
for (var i = 0; i < n; i++)
{
    sList.Add(string.Join("", Console.ReadLine()));
}
sList.Sort((a, b) => a.Length - b.Length);
Console.WriteLine(string.Join("", sList));
