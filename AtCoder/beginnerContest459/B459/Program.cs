var n = int.Parse(Console.ReadLine());
var sList = Console.ReadLine().Split(" ").ToList();

var result = "";
for (var i = 0; i < n; i++)
{
    var s = sList[i];
    var sFirst = s[0].ToString();

    if (sFirst == "a" || sFirst == "b" || sFirst == "c")
    {
        result += "2";
    }
    else if (sFirst == "d" || sFirst == "e" || sFirst == "f")
    {
        result += "3";
    }
    else if (sFirst == "g" || sFirst == "h" || sFirst == "i")
    {
        result += "4";
    }
    else if (sFirst == "j" || sFirst == "k" || sFirst == "l")
    {
        result += "5";
    }
    else if (sFirst == "m" || sFirst == "n" || sFirst == "o")
    {
        result += "6";
    }
    else if (sFirst == "p" || sFirst == "q" || sFirst == "r" || sFirst == "s")
    {
        result += "7";
    }
    else if (sFirst == "t" || sFirst == "u" || sFirst == "v")
    {
        result += "8";
    }
    else
    {
        result += "9";
    }
}

Console.WriteLine(result);
