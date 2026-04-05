var md = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var m = md[0];
var d = md[1];

var result = "No";
if (m == 1)
{
    result = d == 7 ? "Yes" : "No";
}
else if (m == 3)
{
    result = d == 3 ? "Yes" : "No";
}
else if (m == 5)
{
    result = d == 5 ? "Yes" : "No";
}
else if (m == 7)
{
    result = d == 7 ? "Yes" : "No";
}
else if (m == 9)
{
    result = d == 9 ? "Yes" : "No";
}
else
{
    result = "No";
}

Console.WriteLine(result);
