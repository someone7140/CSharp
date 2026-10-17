var nkt = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nkt[0];
var k = nkt[1];
var t = nkt[2];

var aList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
aList.Sort();

var count = 0;
var lastButtonTime = -1;
for (var i = 0; i < n; i++)
{
    var a = aList[i];
    if (a > t)
    {
        if (lastButtonTime == -1)
        {
            count = t / k;
            var amari = t % k;
            if (amari > 0)
            {
                count++;
            }
        }
        else
        {
            var wari = (t - lastButtonTime) / k;
            var amari = (t - lastButtonTime) % k;
            if (wari > 0 && amari == 0)
            {
                wari -= 1;
            }
            count += wari;
        }
        break;
    }
    else
    {
        if (lastButtonTime == -1)
        {
            var wari = a / k;
            var amari = a % k;
            if (a == 0)
            {
                count = 0;
            }
            if (wari == 0)
            {
                count = 1;
            }
            else if (amari > 0)
            {
                count = wari + 1;
            }
            else
            {
                count = wari;
            }
            lastButtonTime = a;
        }
        else
        {
            var sabun = a - lastButtonTime;
            var wari = sabun / k;
            var amari = sabun % k;
            if (wari > 0 && amari == 0)
            {
                wari -= 1;
            }
            count += wari;
            lastButtonTime = a;
        }

        if (i == n - 1)
        {
            var wari = (t - lastButtonTime) / k;
            var amari = (t - lastButtonTime) % k;
            if (wari > 0 && amari == 0)
            {
                wari -= 1;
            }
            count += wari;
        }
    }
}

Console.WriteLine(count);
