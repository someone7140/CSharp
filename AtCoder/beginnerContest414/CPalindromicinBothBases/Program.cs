using System.Text;

var a = int.Parse(Console.ReadLine());
var n = long.Parse(Console.ReadLine());

var result10List = new List<long>();

// 10進数の回文リスト
for (var i = 1; i < 10; i++)
{
    result10List.Add(i);
}

bool endFlag = false;
for (var i = 0; i <= 5; i++)
{
    if (endFlag)
    {
        break;
    }
    var start = (int)Math.Pow(10, i);
    var end = (int)Math.Pow(10, i + 1);
    for (var j = start; j < end; j++)
    {
        var jStr = j.ToString();
        var jLong = long.Parse(jStr + jStr);
        if (jLong > n)
        {
            endFlag = true;
            break;
        }
        result10List.Add(jLong);

        for (var k = 0; k <= 9; k++)
        {
            var kLong = long.Parse(jStr + k + jStr);
            if (kLong > n)
            {
                break;
            }
            result10List.Add(kLong);
        }
    }
}

var result = 0L;
foreach (long result10 in result10List)
{
    var resultStr = ToBase(result10, a);
    if (resultStr.Length == 1)
    {
        result += result10;
    }
    else
    {
        var strLen = resultStr.Length;
        var resultStrHalfSize = strLen / 2;
        var resultStrHalfAmari = strLen % 2;
        var first = resultStr.Substring(0, resultStrHalfSize);
        if (resultStrHalfAmari == 0)
        {
            var last = resultStr.Substring(resultStrHalfSize, resultStrHalfSize);
            if (first == last)
            {
                result += result10;
            }
        }
        else
        {
            var last = resultStr.Substring(resultStrHalfSize + 1, resultStrHalfSize);
            if (first == last)
            {
                result += result10;
            }

        }
    }
}

Console.WriteLine(result);

static string ToBase(long value, long radix)
{
    const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    if (radix < 2 || radix > chars.Length)
        throw new ArgumentOutOfRangeException(nameof(radix));

    if (value == 0) return "0";

    bool negative = value < 0;
    value = Math.Abs(value);

    var sb = new StringBuilder(32);

    while (value > 0)
    {
        var charsIndex = (int)(value % radix);
        sb.Append(chars[charsIndex]);
        value /= radix;
    }

    if (negative)
        sb.Append('-');

    // 逆順にする
    for (int i = 0, j = sb.Length - 1; i < j; i++, j--)
        (sb[i], sb[j]) = (sb[j], sb[i]);

    return sb.ToString();
}