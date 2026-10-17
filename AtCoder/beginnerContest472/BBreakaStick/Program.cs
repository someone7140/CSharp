var n = int.Parse(Console.ReadLine());
var lList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

var result = -1;
for (var i = 0; i < n; i++)
{
    var left = 0;
    var right = 0;
    for (var j = 0; j < n; j++)
    {
        if (j <= i)
        {
            if (i == n - 1)
            {
                right += lList[j];
            }
            else
            {
                left += lList[j];
            }
        }
        else
        {
            right += lList[j];
        }
    }

    var sabun = Math.Abs(left - right);
    if (result == -1 || sabun < result)
    {
        result = sabun;
    }
}

Console.WriteLine(result);
