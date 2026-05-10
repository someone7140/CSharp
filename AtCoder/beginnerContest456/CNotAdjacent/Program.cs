var sStrings = Console.ReadLine().ToCharArray().Select(c => c.ToString()).ToList();
var sCount = sStrings.Count;

var result = 0L;
var bunbo = 998244353L;
var mojisuu = 0;
var beforeMoji = "";

for (var i = 0; i < sCount; i++)
{
    if (beforeMoji == sStrings[i])
    {
        for (var j = mojisuu; j >= 1; j--)
        {
            result = (result + j) % bunbo;
        }
        if (i == sCount - 1)
        {
            result = (result + 1) % bunbo;
        }
        mojisuu = 1;
    }
    else if (i == sCount - 1)
    {
        mojisuu++;
        for (var j = mojisuu; j >= 1; j--)
        {
            result = (result + j) % bunbo;
        }
    }
    else
    {
        mojisuu++;
    }

    beforeMoji = sStrings[i];
}

Console.WriteLine(result);
