var n = int.Parse(Console.ReadLine());
var sList = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();

var linkedList = new LinkedList<string>();
var hanten = false;

for (var i = 0; i < n; i++)
{
    if (i == 0)
    {
        linkedList.AddLast((i + 1).ToString());
    }
    else
    {
        var s = sList[i];
        if (hanten)
        {
            if (s == "o")
            {
                linkedList.AddFirst((i + 1).ToString());
                hanten = false;
            }
            else
            {
                linkedList.AddFirst((i + 1).ToString());
            }
        }
        else
        {
            if (s == "o")
            {
                linkedList.AddLast((i + 1).ToString());
                hanten = true;
            }
            else
            {
                linkedList.AddLast((i + 1).ToString());
            }

        }
    }
}

var resultList = linkedList.ToList();
if (hanten)
{
    resultList.Reverse();
}
Console.WriteLine(string.Join(" ", resultList));
