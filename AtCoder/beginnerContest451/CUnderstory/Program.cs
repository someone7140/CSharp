var q = int.Parse(Console.ReadLine());

var hQueue = new PriorityQueue<int, int>();
var resultArray = new int[q];
var nowCount = 0;
for (var i = 0; i < q; i++)
{
    var ab = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var a = ab[0];
    var b = ab[1];

    if (a == 1)
    {
        hQueue.Enqueue(b, b);
        nowCount++;
    }
    else
    {
        while (true)
        {
            var isGet = !hQueue.TryPeek(out var nowHeight1, out var nowHeight2);
            if (isGet)
            {
                break;
            }
            if (nowHeight1 <= b)
            {
                hQueue.Dequeue();
                nowCount--;
            }
            else
            {
                break;
            }
        }
    }
    resultArray[i] = nowCount;
}

var resultList = new List<string>();
for (var i = 0; i < q; i++)
{
    resultList.Add(resultArray[i].ToString());
}
Console.WriteLine(string.Join("\n", resultList));
