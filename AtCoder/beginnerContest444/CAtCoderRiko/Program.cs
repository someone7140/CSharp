var n = int.Parse(Console.ReadLine());
var aList = Console.ReadLine().Split(" ").Select(int.Parse).OrderByDescending(x => x).ToList();

var result1 = -1;
var max = 0;
var isNotMaxFlag = false;
var result1Success = true;
var matsubiIndex = 999999999;
for (var i = 0; i < n; i++)
{
    if (i == 0)
    {
        max = aList[i];
    }
    else
    {
        if (max != aList[i])
        {
            if (matsubiIndex > i)
            {
                if (!isNotMaxFlag)
                {
                    var remainCount = n - i;
                    if (remainCount % 2 > 0)
                    {
                        result1Success = false;
                        break;
                    }
                    isNotMaxFlag = true;
                    matsubiIndex = n - 1;
                }
                if (isNotMaxFlag)
                {
                    var tempSum = aList[i] + aList[matsubiIndex];
                    if (max != tempSum)
                    {
                        result1Success = false;
                        break;
                    }
                    matsubiIndex--;
                }
            }
            else
            {
                break;
            }
        }
    }
}
if (result1Success)
{
    result1 = max;
}

var result2 = -1;
var result2Success = true;
matsubiIndex = n - 1;
var target = -1;
if (n % 2 == 0)
{
    for (var i = 0; i < n; i++)
    {
        if (i == 0)
        {
            target = aList[i] + aList[matsubiIndex];
            matsubiIndex--;
        }
        else
        {
            if (matsubiIndex > i)
            {
                var tempSum = aList[i] + aList[matsubiIndex];
                if (target != tempSum)
                {
                    result2Success = false;
                    break;
                }
                matsubiIndex--;
            }
            else
            {
                break;
            }
        }
    }
}
else
{
    result2Success = false;
}


if (result1Success && result2Success)
{
    Console.WriteLine(max.ToString() + " " + target.ToString());
}
else if (result1Success)
{
    Console.WriteLine(max);
}
else if (result2Success)
{
    Console.WriteLine(target);
}
