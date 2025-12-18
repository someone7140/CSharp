class A22222
{
    static void Main()
    {
        var sArray = Console.ReadLine()?.Where(s => s.Equals('2')).ToArray();
        var result = string.Join("", sArray);
        Console.WriteLine(result);
    }
}
