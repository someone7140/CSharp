var nk = Console.ReadLine().Split(" ").Select(long.Parse).ToList();
var n = nk[0];
var k = nk[1];

var result = 0;
var sum = n;
var index = 0;
while (sum < k)
{
    index++;
    sum += n + index;
    result++;
}

Console.WriteLine(result);
