var sList = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();
var queueAIndex = new Queue<int>();
var queueBIndex = new Queue<int>();
var queueCIndex = new Queue<int>();
var sLen = sList.Count;

for (var i = 0; i < sLen; i++)
{
    var s = sList[i];
    if (s == "A")
    {
        queueAIndex.Enqueue(i);
    }
    if (s == "B")
    {
        queueBIndex.Enqueue(i);
    }
    if (s == "C")
    {
        queueCIndex.Enqueue(i);
    }
}

var result = 0;
while (true)
{
    var aIndex = -1;
    if (!queueAIndex.TryPeek(out aIndex))
    {
        break;
    }
    var bIndex = -1;
    if (!queueBIndex.TryPeek(out bIndex))
    {
        break;
    }
    var cIndex = -1;
    if (!queueCIndex.TryPeek(out cIndex))
    {
        break;
    }

    if (aIndex < bIndex && bIndex < cIndex)
    {
        result++;
        queueAIndex.Dequeue();
        queueBIndex.Dequeue();
        queueCIndex.Dequeue();
    }
    else if (aIndex > bIndex)
    {
        queueBIndex.Dequeue();
    }
    else if (bIndex > cIndex)
    {
        queueCIndex.Dequeue();
    }
}

Console.WriteLine(result);
