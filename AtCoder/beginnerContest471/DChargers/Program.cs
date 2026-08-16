var qv = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var q = qv[0];
var v = qv[1];

PriorityQueue<int, int> priQueue = new();

var resultList = new List<string>();
for (var i = 0; i < q; i++)
{
    var qs = Console.ReadLine().Split(" ");
    if (qs[0] == "1")
    {
        var t = int.Parse(qs[1]);
        var w = int.Parse(qs[2]);
        priQueue.Enqueue(w - t, -(w - t));
    }
    else
    {
        if (priQueue.Count == 0)
        {
            resultList.Add("-1");
        }
        else
        {
            var t = int.Parse(qs[1]);
            var result = priQueue.Dequeue() + t;
            if (result > v)
            {
                resultList.Add(v.ToString());
            }
            else
            {
                resultList.Add(result.ToString());
            }
        }
    }
}

Console.WriteLine(string.Join("\n", resultList));
