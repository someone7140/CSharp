var hw = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var h = hw[0];
var w = hw[1];

var countArrayArray = new int[h, w];
var sListList = new List<List<string>>();
var warpDict = new Dictionary<string, List<Position>>();
for (var i = 0; i < h; i++)
{
    var sList = new List<string>();
    var sCharList = Console.ReadLine().ToCharArray();
    for (var j = 0; j < w; j++)
    {
        countArrayArray[i, j] = -1;
        var s = sCharList[j].ToString();
        sList.Add(s);
        if (s != "." && s != "#")
        {
            if (warpDict.ContainsKey(s))
            {
                warpDict[s].Add(new Position
                {
                    H = i,
                    W = j,
                    Count = 0
                });
            }
            else
            {
                warpDict[s] =
                [
                    new Position
                    {
                        H = i,
                        W = j,
                        Count = 0
                    }
                ];
            }
        }

    }
    sListList.Add(sList);
}

var warpMoji = new HashSet<string>();
var queue = new Queue<Position>();
var result = -1;

queue.Enqueue(new Position { H = 0, W = 0, Count = 0 });
countArrayArray[0, 0] = 0;

while (true)
{
    try
    {
        var pos = queue.Dequeue();
        if (pos.H == h - 1 && pos.W == w - 1)
        {
            if (result == -1 || result > pos.Count)
            {
                result = pos.Count;
            }
            continue;
        }


        if (pos.H == 0 && pos.W == 0)
        {
            NextExec(pos.H, pos.W, pos.Count);
        }

        if (pos.H > 0)
        {
            NextExec(pos.H - 1, pos.W, pos.Count);
        }
        if (pos.W > 0)
        {
            NextExec(pos.H, pos.W - 1, pos.Count);
        }
        if (pos.H < h - 1)
        {
            NextExec(pos.H + 1, pos.W, pos.Count);
        }
        if (pos.W < w - 1)
        {
            NextExec(pos.H, pos.W + 1, pos.Count);
        }
    }
    catch (Exception _)
    {
        break;
    }
}

Console.WriteLine(result);

void NextExec(int nextH, int nextW, int count)
{
    var next = sListList[nextH][nextW];
    if (next == ".")
    {
        if (countArrayArray[nextH, nextW] == -1 || countArrayArray[nextH, nextW] > count + 1)
        {
            countArrayArray[nextH, nextW] = count + 1;
            queue.Enqueue(new Position { H = nextH, W = nextW, Count = count + 1 });
        }
    }
    else if (next != "#")
    {
        if (!warpMoji.Contains(next))
        {
            var warpList = warpDict[next];
            if (nextH == 0 && nextW == 0)
            {
                countArrayArray[nextH, nextW] = count;
            }
            else
            {
                countArrayArray[nextH, nextW] = count + 1;

            }

            foreach (Position warpPos in warpList)
            {
                if (warpPos.H != nextH || warpPos.W != nextW)
                {
                    if (countArrayArray[warpPos.H, warpPos.W] == -1 || countArrayArray[warpPos.H, warpPos.W] > countArrayArray[nextH, nextW] + 1)
                    {
                        countArrayArray[warpPos.H, warpPos.W] = countArrayArray[nextH, nextW] + 1;
                        queue.Enqueue(new Position { H = warpPos.H, W = warpPos.W, Count = countArrayArray[nextH, nextW] + 1 });
                    }
                }
            }
            warpMoji.Add(next);
        }
    }
}

class Position
{
    public required int H { get; set; }

    public required int W { get; set; }
    public required int Count { get; set; }
}

