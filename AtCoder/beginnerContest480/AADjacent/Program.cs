var list0 = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();
var list1 = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();

var aRow = -1;
var aColumn = -1;
if (list0[0] == "A")
{
    aRow = 0;
    aColumn = 0;
}
if (list0[1] == "A")
{
    aRow = 0;
    aColumn = 1;
}
if (list1[0] == "A")
{
    aRow = 1;
    aColumn = 0;
}
if (list1[1] == "A")
{
    aRow = 1;
    aColumn = 1;
}

var dRow = -1;
var dColumn = -1;
if (list0[0] == "D")
{
    dRow = 0;
    dColumn = 0;
}
if (list0[1] == "D")
{
    dRow = 0;
    dColumn = 1;
}
if (list1[0] == "D")
{
    dRow = 1;
    dColumn = 0;
}
if (list1[1] == "D")
{
    dRow = 1;
    dColumn = 1;
}

if (aRow == dRow || aColumn == dColumn)
{
    Console.WriteLine("Yes");
}
else
{
    Console.WriteLine("No");
}
