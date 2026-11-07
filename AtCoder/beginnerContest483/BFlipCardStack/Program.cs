var nq = Console.ReadLine().Split(" ").ToList();
var n = int.Parse(nq[0]);
var q = int.Parse(nq[1]);

var kList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

var cardList = new List<int>();

for (var i = 1; i <= n; i++)
{
    cardList.Add(i);
}

foreach (var k in kList)
{
    var cardList2 = new List<int>();
    for (var i = 0; i < n; i++)
    {
        if (i < k)
        {
            cardList2.Add(cardList[k - i - 1] * -1);
        }
        else
        {
            cardList2.Add(cardList[i]);
        }
    }
    cardList = cardList2;
}

var resultList = new List<string>();
foreach (var card in cardList)
{
    resultList.Add(card.ToString());
}

Console.WriteLine(string.Join("\n", resultList));
