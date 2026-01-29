var q = int.Parse(Console.ReadLine());

var onryou = 0;
var isSaisei = false;
var resultList = new List<string>();

for (var i = 0; i < q; i++)
{
    var a = int.Parse(Console.ReadLine());
    if (a == 1)
    {
        onryou++;
    }
    if (a == 2)
    {
        if (onryou >= 1)
        {
            onryou--;
        }
    }
    if (a == 3)
    {
        isSaisei = !isSaisei;
    }

    if (isSaisei && onryou >= 3)
    {
        resultList.Add("Yes");
    }
    else
    {
        resultList.Add("No");
    }
}

Console.WriteLine(string.Join("\n", resultList));
