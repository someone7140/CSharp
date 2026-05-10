var hw = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var h = hw[0];
var w = hw[1];

var sArrayArray = new string[h, w];
var sVisitArrayArray = new VisitDirection[h, w];
var startH = 0;
var startW = 0;
for (var i = 0; i < h; i++)
{
    var sArray = Console.ReadLine().ToCharArray();
    for (var j = 0; j < w; j++)
    {
        sArrayArray[i, j] = sArray[j].ToString();
        if (sArrayArray[i, j] == "S")
        {
            startH = i;
            startW = j;
        }
        sVisitArrayArray[i, j] = new VisitDirection
        {
            UpperFlag = false,
            DownFlag = false,
            RightFlag = false,
            LeftFlag = false
        };
    }
}

var result = "No";
var resultKeiroList = new List<string>();
var resultKeiroCount = 0;

loopTree(startH, startW, "");
if (result == "No")
{
    Console.WriteLine(result);
}
else
{
    Console.WriteLine(result);
    Console.WriteLine(string.Join("", resultKeiroList));
}

void loopTree(int nowH, int nowW, string beforeDirection)
{
    var nowMasu = sArrayArray[nowH, nowW];
    var upperVisitFlag = sVisitArrayArray[nowH, nowW].UpperFlag;
    var downVisitFlag = sVisitArrayArray[nowH, nowW].DownFlag;
    var rightVisitFlag = sVisitArrayArray[nowH, nowW].RightFlag;
    var leftVisitFlag = sVisitArrayArray[nowH, nowW].LeftFlag;

    if (nowMasu == "#")
    {
        return;
    }

    if (resultKeiroCount > 5000000)
    {
        return;
    }
    if (nowMasu == "G")
    {
        result = "Yes";
        return;
    }

    if (nowMasu == "x")
    {
        if (beforeDirection == "U")
        {
            if (downVisitFlag && rightVisitFlag && leftVisitFlag)
            {
                return;
            }
        }

        if (beforeDirection == "D")
        {
            if (upperVisitFlag && rightVisitFlag && leftVisitFlag)
            {
                return;
            }
        }

        if (beforeDirection == "L")
        {
            if (upperVisitFlag && rightVisitFlag && downVisitFlag)
            {
                return;
            }
        }

        if (beforeDirection == "R")
        {
            if (upperVisitFlag && leftVisitFlag && downVisitFlag)
            {
                return;
            }
        }
    }

    if (nowMasu == "o")
    {
        if (beforeDirection == "U" && upperVisitFlag)
        {
            return;
        }
        if (beforeDirection == "D" && downVisitFlag)
        {
            return;
        }
        if (beforeDirection == "L" && leftVisitFlag)
        {
            return;
        }
        if (beforeDirection == "R" && rightVisitFlag)
        {
            return;
        }
    }

    if (nowMasu != "o" && nowMasu != "x")
    {
        if (upperVisitFlag || downVisitFlag || rightVisitFlag || leftVisitFlag)
        {
            return;
        }
    }

    if (nowH > 0 && !upperVisitFlag)
    {
        var upperSusumuFlag = true;
        if (nowMasu == "o")
        {
            if (beforeDirection != "U")
            {
                upperSusumuFlag = false;
            }
        }
        else if (nowMasu == "x")
        {
            if (beforeDirection == "U")
            {
                upperSusumuFlag = false;
            }
        }

        if (upperSusumuFlag)
        {
            resultKeiroCount += 1;
            resultKeiroList.Add("U");
            sVisitArrayArray[nowH, nowW].UpperFlag = true;
            loopTree(nowH - 1, nowW, "U");
            if (result == "Yes")
            {
                return;
            }
            resultKeiroList.RemoveAt(resultKeiroCount - 1);
            resultKeiroCount -= 1;
            sVisitArrayArray[nowH, nowW].UpperFlag = false;
        }
    }

    if (nowH < h - 1 && !downVisitFlag)
    {
        var downSusumuFlag = true;
        if (nowMasu == "o")
        {
            if (beforeDirection != "D")
            {
                downSusumuFlag = false;
            }
        }
        else if (nowMasu == "x")
        {
            if (beforeDirection == "D")
            {
                downSusumuFlag = false;
            }
        }

        if (downSusumuFlag)
        {
            resultKeiroCount += 1;
            resultKeiroList.Add("D");
            sVisitArrayArray[nowH, nowW].DownFlag = true;
            loopTree(nowH + 1, nowW, "D");
            if (result == "Yes")
            {
                return;
            }
            resultKeiroList.RemoveAt(resultKeiroCount - 1);
            resultKeiroCount -= 1;
            sVisitArrayArray[nowH, nowW].DownFlag = false;
        }
    }

    if (nowW > 0 && !leftVisitFlag)
    {
        var leftSusumuFlag = true;
        if (nowMasu == "o")
        {
            if (beforeDirection != "L")
            {
                leftSusumuFlag = false;
            }
        }
        else if (nowMasu == "x")
        {
            if (beforeDirection == "L")
            {
                leftSusumuFlag = false;
            }
        }

        if (leftSusumuFlag)
        {
            resultKeiroCount += 1;
            resultKeiroList.Add("L");
            sVisitArrayArray[nowH, nowW].LeftFlag = true;
            loopTree(nowH, nowW - 1, "L");
            if (result == "Yes")
            {
                return;
            }
            resultKeiroList.RemoveAt(resultKeiroCount - 1);
            resultKeiroCount -= 1;
            sVisitArrayArray[nowH, nowW].LeftFlag = false;
        }
    }

    if (nowW < w - 1 && !rightVisitFlag)
    {
        var rightSusumuFlag = true;
        if (nowMasu == "o")
        {
            if (beforeDirection != "R")
            {
                rightSusumuFlag = false;
            }
        }
        else if (nowMasu == "x")
        {
            if (beforeDirection == "R")
            {
                rightSusumuFlag = false;
            }
        }

        if (rightSusumuFlag)
        {
            resultKeiroCount += 1;
            resultKeiroList.Add("R");
            sVisitArrayArray[nowH, nowW].RightFlag = true;
            loopTree(nowH, nowW + 1, "R");
            if (result == "Yes")
            {
                return;
            }
            resultKeiroList.RemoveAt(resultKeiroCount - 1);
            resultKeiroCount -= 1;
            sVisitArrayArray[nowH, nowW].RightFlag = false;
        }
    }
}

class VisitDirection
{
    public required bool UpperFlag { get; set; }

    public required bool DownFlag { get; set; }

    public required bool RightFlag { get; set; }

    public required bool LeftFlag { get; set; }
}
