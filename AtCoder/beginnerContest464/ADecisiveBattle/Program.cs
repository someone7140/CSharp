var sList = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();
var eCount = 0;
var wCount = 0;

foreach (var s in sList)
{
    if (s == "E")
    {
        eCount++;
    }
    else
    {
        wCount++;

    }
}

if (eCount > wCount)
{
    Console.WriteLine("East");
}
else
{
    Console.WriteLine("West");
}
