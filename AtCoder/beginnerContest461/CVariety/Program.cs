var nkm = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var n = nkm[0];
var k = nkm[1];
var m = nkm[2];

var cvList = new List<CVariety>();

for (var i = 0; i < n; i++)
{
    var cv = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
    var cVariety = new CVariety
    {
        Syurui = cv[0],
        Value = cv[1]
    };
    cvList.Add(cVariety);
}

var sortedCv = cvList.OrderBy(x => -x.Value)
    .ThenBy(x => x.Syurui)
    .ToList();
var syruiCountDict = new Dictionary<int, int>();
var syruiValuesDict = new Dictionary<int, List<long>>();
var deleteTarget = new List<CVariety>();
var syuruiCount = 0;
var selectCount = 0;
var result = 0L;

for (var i = 0; i < n; i++)
{
    var cv = sortedCv[i];
    var addSyuruiFlag = false;
    if (!syruiCountDict.ContainsKey(cv.Syurui))
    {
        addSyuruiFlag = true;
        syruiCountDict[cv.Syurui] = 1;
        syruiValuesDict[cv.Syurui] = [cv.Value];
        syuruiCount++;
    }
    else
    {
        syruiCountDict[cv.Syurui] += 1;
        syruiValuesDict[cv.Syurui].Add(cv.Value);
        deleteTarget.Add(cv);
    }
    selectCount++;
    result += cv.Value;

    if (k == selectCount)
    {
        if (syuruiCount >= m)
        {
            break;
        }
        else
        {
            if (addSyuruiFlag)
            {
                var del = deleteTarget[^1];
                syruiCountDict[del.Syurui] -= 1;
                syruiValuesDict[del.Syurui].RemoveAt(syruiValuesDict[del.Syurui].Count - 1);
                result -= del.Value;
                deleteTarget.RemoveAt(deleteTarget.Count - 1);
            }
            else
            {
                syruiCountDict[cv.Syurui] -= 1;
                syruiValuesDict[cv.Syurui].RemoveAt(syruiValuesDict[cv.Syurui].Count - 1);
                deleteTarget.RemoveAt(deleteTarget.Count - 1);
                result -= cv.Value;
            }
            selectCount--;
        }
    }

}

Console.WriteLine(result);

class CVariety
{
    public required int Syurui { get; set; }

    public required long Value { get; set; }

}
