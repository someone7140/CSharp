var n = int.Parse(Console.ReadLine());
var start = 1;
var end = 2;

var result = 0;

while (true)
{
    Console.WriteLine("? " + start + " " + end);
    var ans = Console.ReadLine();
    if (ans == "Yes")
    {
        result += end - start;
        if (end == n)
        {
            break;
        }
        else
        {
            end++;
        }
    }
    else
    {
        start++;
        if (start == end)
        {
            if (end == n)
            {
                break;
            }
            else
            {
                end++;
            }

        }
    }
}

Console.WriteLine("! " + result);
