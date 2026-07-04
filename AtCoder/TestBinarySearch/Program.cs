List<int> testList = [2, 4, 6, 8, 10];

// 該当する値がListにある場合は、そのインデックスが返る（4を指定した場合は1が返る）
Console.WriteLine(testList.BinarySearch(4));

// 該当する値がListに無い場合は、それより大きい最初の要素のインデックスが反転したビットで返る（5を指定した場合は-3が返る）
var result5 = testList.BinarySearch(5);
Console.WriteLine(result5);
Console.WriteLine(~result5);

// 該当する値がListの最小値より小さい場合は、それより大きい最初の要素のインデックスが反転したビットで返る（1を指定した場合は-1が返る）
var result1 = testList.BinarySearch(1);
Console.WriteLine(result1);
Console.WriteLine(~result1);

// 該当する値がListの最大値より大きい場合は、最後のインデックス+1が反転したビットで返る（11を指定した場合は-6が返る）
var result11 = testList.BinarySearch(11);
Console.WriteLine(result11);
Console.WriteLine(~result11);
