var hwk = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
var h = hwk[0];
var w = hwk[1];
var k = hwk[2];

var sArrayArray = new string[h, w];
var sCountArrayArray = new int[h, w];
var bombHSet = new HashSet<int>();
var bombWSet = new HashSet<int>();

for (var i = 0; i < h; i++)
{
    var sCharArray = Console.ReadLine().ToCharArray();
    for (var j = 0; j < w; j++)
    {
        var s = sCharArray[j].ToString();
        if (s == "#")
        {
            bombHSet.Add(i);
            bombWSet.Add(j);
        }
        sArrayArray[i, j] = s;
        sCountArrayArray[i, j] = -1;
    }
}

var result = 0;
for (var i = 0; i < h; i++)
{
    for (var j = 0; j < w; j++)
    {
        if (sArrayArray[i, j] != "#")
        {
            var queue = new Queue<Position>();
            queue.Enqueue(new Position { H = i, W = j, Count = 0, Histories = [] });
            while (queue.Count > 0)
            {
                var pos = queue.Dequeue();
                if (!bombHSet.Contains(pos.H) && !bombWSet.Contains(pos.W))
                {
                    sCountArrayArray[i, j] = pos.Count;
                    sCountArrayArray[pos.H, pos.W] = 0;
                    writeCount(pos);
                    result++;
                    break;
                }
                else
                {
                    // 上に行く
                    if (pos.H > 0)
                    {
                        var memoCount = sCountArrayArray[pos.H - 1, pos.W];
                        if (memoCount == -1)
                        {
                            if (pos.Count < k)
                            {
                                queue.Enqueue(new Position { H = pos.H - 1, W = pos.W, Count = pos.Count + 1 });
                            }
                        }
                        else
                        {
                            var tempCount = memoCount + pos.Count + 1;
                            if (tempCount <= k)
                            {
                                sCountArrayArray[i, j] = tempCount;
                                sCountArrayArray[pos.H - 1, pos.W] = 0;
                                result++;
                                break;
                            }
                        }
                    }

                    // 下に行く
                    if (pos.H < n - 1)
                    {
                        var memoCount = sCountArrayArray[pos.H + 1, pos.W];
                        if (memoCount == -1)
                        {
                            if (pos.Count < k)
                            {
                                queue.Enqueue(new Position { H = pos.H + 1, W = pos.W, Count = pos.Count + 1 });
                            }
                        }
                        else
                        {
                            var tempCount = memoCount + pos.Count + 1;
                            if (tempCount <= k)
                            {
                                sCountArrayArray[i, j] = tempCount;
                                sCountArrayArray[pos.H + 1, pos.W] = 0;
                                result++;
                                break;
                            }
                        }
                    }

                    // 左に行く
                    if (pos.W > 0)
                    {
                        var memoCount = sCountArrayArray[pos.H, pos.W - 1];
                        if (memoCount == -1)
                        {
                            if (pos.Count < k)
                            {
                                queue.Enqueue(new Position { H = pos.H, W = pos.W - 1, Count = pos.Count + 1 });
                            }
                        }
                        else
                        {
                            var tempCount = memoCount + pos.Count + 1;
                            if (tempCount <= k)
                            {
                                sCountArrayArray[i, j] = tempCount;
                                sCountArrayArray[pos.H, pos.W] = 0;
                                result++;
                                break;
                            }
                        }
                    }

                }
            }
        }
    }
}

Console.WriteLine(result);

void writeCount(Position pos)
{
    var hisLen = pos.histories.Count;
    for (var i = 0; i < hisLen; i++)
    {
        var tempCount = pos.count - i - 1;
        var hw = pos.histories[i].Split("-");
        sCountArrayArray[int.Parse(hw[0]), int.Parse(hw[1])] = tempCount;
    }
}

class Position
{
    public required int H { get; set; }

    public required int W { get; set; }
    public required int Count { get; set; }
    public required List<string> Histories { get; set; }
}

