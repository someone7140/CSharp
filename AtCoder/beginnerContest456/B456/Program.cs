var a1List = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var a2List = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var a3List = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

var a1Count4 = a1List.Count(a => a == 4);
var a1Count5 = a1List.Count(a => a == 5);
var a1Count6 = a1List.Count(a => a == 6);

var a2Count4 = a2List.Count(a => a == 4);
var a2Count5 = a2List.Count(a => a == 5);
var a2Count6 = a2List.Count(a => a == 6);

var a3Count4 = a3List.Count(a => a == 4);
var a3Count5 = a3List.Count(a => a == 5);
var a3Count6 = a3List.Count(a => a == 6);

double bunbo = 6 * 6 * 6;
var result = a1Count4 * a2Count5 * a3Count6 / bunbo
+ a1Count4 * a2Count6 * a3Count5 / bunbo
+ a1Count5 * a2Count4 * a3Count6 / bunbo
+ a1Count5 * a2Count6 * a3Count4 / bunbo
+ a1Count6 * a2Count4 * a3Count5 / bunbo
+ a1Count6 * a2Count5 * a3Count4 / bunbo;
Console.WriteLine(result);
