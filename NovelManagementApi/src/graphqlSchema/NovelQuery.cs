namespace NovelManagementApi.src.graphqlSchema;

[ExtendObjectType("Query")]
public class NovelQuery
{
    public string Hello2()
    {
        Console.WriteLine("=== Hello method called ===");

        var message = "Hello, GraphQL!";

        Console.WriteLine($"Message: {message}");
        Console.WriteLine($"Timestamp: {DateTime.Now}");

        return message;
    }
}
