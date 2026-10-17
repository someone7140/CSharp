var n = int.Parse(Console.ReadLine());
var aList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

var kouka1 = 0;
var kouka10 = 0;
var kouka100 = 0;

for (var i = 0; i < n; i++)
{
    var amari1000 = aList[i] % 1000;
    if (amari1000 > 0)
    {
        var otsuri = 1000 - amari1000;

        var otusri100 = otsuri / 100;
        kouka100 += otusri100;

        var otusri10 = (otsuri - otusri100 * 100) / 10;
        kouka10 += otusri10;

        var otusri1 = otsuri - otusri100 * 100 - otusri10 * 10;
        kouka1 += otusri1;
    }
}

Console.WriteLine(kouka1.ToString() + " " + kouka10.ToString() + " " + kouka100.ToString());
