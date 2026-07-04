var nx = Console.ReadLine().Split(" ").ToList();
var n = int.Parse(nx[0]);
var x = nx[1];

var result = "No";
var index = -1;

if (x == "A")
{
    index = 0;
}
if (x == "B")
{
    index = 1;
}
if (x == "C")
{
    index = 2;
}
if (x == "D")
{
    index = 3;
}
if (x == "E")
{
    index = 4;
}

for (var i = 0; i < n; i++)
{
    var sList = Console.ReadLine().ToCharArray().ToList();
    if (sList[index] == 'o')
    {
        result = "Yes";
    }
}

Console.WriteLine(result);
