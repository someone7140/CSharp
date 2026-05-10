var n = int.Parse(Console.ReadLine());
var sList = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();

var result = "";
var notOFlag = false;
foreach (string s in sList)
{
    if (notOFlag)
    {
        result += s;
    }
    else
    {
        if (s != "o")
        {
            result += s;
            notOFlag = true;
        }
    }

}
Console.WriteLine(result);
