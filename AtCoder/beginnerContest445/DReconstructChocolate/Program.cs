var hwn = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var h = hwn[0];
var w = hwn[1];
var n = hwn[2];

var pieceList = new List<ChocolatePiece>();
for (var i = 0; i < n; i++)
{
    var hw = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var piece = new ChocolatePiece
    {

        Height = hw[0],
        Width = hw[1],
        Index = i,
    };
    pieceList.Add(piece);

}
pieceList.Sort((a, b) => Math.Max(b.Height, b.Width) - Math.Max(a.Height, a.Width));

var resultList = new string[n];
var candidateSet = new HashSet<string>
{
    "0-0"
};

foreach (var piece in pieceList)
{
    var candidateRemove = "";
    foreach (var candidate in candidateSet)
    {
        var cStrings = candidate.Split("-");
        var hIndex = int.Parse(cStrings[0]);
        var wIndex = int.Parse(cStrings[1]);
        var sita = hIndex + piece.Height - 1;
        var migi = wIndex + piece.Width - 1;
        if (sita < h && migi < w)
        {
            candidateRemove = candidate;
            resultList[piece.Index] = (hIndex + 1) + " " + (wIndex + 1);
            if (sita < h - 1)
            {
                candidateSet.Add((sita + 1) + "-" + (wIndex));
            }
            if (migi < w - 1)
            {
                candidateSet.Add(hIndex + "-" + (migi + 1));
            }
            break;
        }
    }
    candidateSet.Remove(candidateRemove);
}

Console.WriteLine(string.Join("\n", resultList));

class ChocolatePiece
{
    public required int Height { get; set; }

    public required int Width { get; set; }
    public required int Index { get; set; }
}
