var t = int.Parse(Console.ReadLine());
var resultList = new List<string>();

for (var i = 0; i < t; i++)
{
    var aRles = getRle(Console.ReadLine());
    var bRles = getRle(Console.ReadLine());
    var aCount = aRles.Count;
    var bCount = bRles.Count;
    var aIndex = 0;
    var bIndex = 0;
    var result = "Yes";
    while (aIndex < aCount && bIndex < bCount)
    {
        var a = aRles[aIndex];
        var b = aRles[bIndex];
        if (a.Moji == b.Moji && a.Count == b.Count)
        {
            aIndex++;
            bIndex++;
        }
        else
        {
            if (a.Moji == "(" && b.Moji == "x")
            {
                if (aIndex + 2 < aCount)
                {
                    var aNext1 = aRles[aIndex + 1];
                    var aNext2 = aRles[aIndex + 2];
                    if (aNext1.Count == 2 && aNext2.Moji == ")")
                    {
                        if (a.Count > aNext2.Count)
                        {
                            result = "No";
                            break;
                        }
                        else if (a.Count == aNext2.Count)
                        {
                            aIndex += 3;
                            bIndex += 1;
                        }
                        else
                        {
                            aRles[aIndex + 2] = new RleString
                            {
                                Moji = ")",
                                Count = aNext2.Count - a.Count,
                            };
                            aIndex += 2;
                            bIndex += 1;
                        }
                    }
                    else
                    {
                        result = "No";
                        break;
                    }
                }
                else
                {
                    result = "No";
                    break;
                }
            }
            else if (a.Moji == "x" && b.Moji == "(")
            {
                if (a.Count < 2)
                {
                    result = "No";
                    break;
                }

                if (bIndex + 2 < bCount)
                {
                    var bNext1 = bRles[bIndex + 1];
                    var bNext2 = bRles[bIndex + 2];
                    if (bNext1.Moji == "x" && bNext1.Count == 2 && bNext2.Moji == ")")
                    {
                        if (b.Count > bNext2.Count)
                        {
                            result = "No";
                            break;
                        }
                        else if (b.Count == bNext2.Count)
                        {
                            if (a.Count == 2)
                            {
                                aIndex += 1;
                            }
                            else
                            {
                                aRles[aIndex] = new RleString
                                {
                                    Moji = "x",
                                    Count = a.Count - 2,
                                };
                            }
                            bIndex += 3;
                        }
                        else
                        {
                            if (aIndex + 1 < aCount && a.Count == 2)
                            {
                                if (bNext2.Count == b.Count + aRles[aIndex + 1].Count)
                                {
                                    aIndex += 2;
                                    bIndex += 3;
                                }
                                else
                                {
                                    result = "No";
                                    break;
                                }
                            }
                            else
                            {
                                result = "No";
                                break;
                            }
                        }
                    }
                    else
                    {
                        result = "No";
                        break;
                    }
                }
                else
                {
                    result = "No";
                    break;
                }
            }
            else
            {
                result = "No";
                break;
            }
        }
    }

    if (aIndex != aCount || bIndex != bCount)
    {
        result = "No";
    }

    resultList.Add(result);
}


Console.WriteLine(string.Join("\n", resultList));


List<RleString> getRle(string testMoji)
{
    var rleList = new List<RleString>();
    var mojiList = testMoji.ToCharArray().Select(c => c.ToString()).ToList();
    var mojiCount = mojiList.Count;
    var beforeMoji = "";
    var count = 0;
    for (var i = 0; i < mojiCount; i++)
    {
        var moji = mojiList[i];
        if (i == 0)
        {
            beforeMoji = moji;
            count = 1;
        }
        else if (beforeMoji == moji)
        {
            count++;
        }
        else
        {
            rleList.Add(new RleString
            {
                Moji = beforeMoji,
                Count = count,
            });
            beforeMoji = moji;
            count = 1;
        }

        if (i == mojiCount - 1)
        {
            rleList.Add(new RleString
            {
                Moji = beforeMoji,
                Count = count,
            });
        }
    }

    return rleList;
}

class RleString
{
    public required string Moji { get; set; }

    public required int Count { get; set; }
}

