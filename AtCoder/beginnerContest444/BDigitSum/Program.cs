var nk = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nk[0];
var k = nk[1];

var result = 0;
for (var i = 1; i <= n; i++)
{
    var nChars = i.ToString().ToCharArray().ToList();
    var tempSum = 0;
    foreach (char nChar in nChars)
    {
        tempSum += int.Parse(nChar.ToString());
    }

    if (tempSum == k)
    {
        result++;
    }

}

Console.WriteLine(result);