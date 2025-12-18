namespace NovelManagementApi.src.graphqlSchema;

using System.Threading.Tasks;
using NovelManagementApi.src.service;


[ExtendObjectType("Query")]
public class UserAccountQuery
{
    public string Hello()
    {
        Console.WriteLine("=== Hello method called ===");

        var message = "Hello, GraphQL!";

        Console.WriteLine($"Message: {message}");
        Console.WriteLine($"Timestamp: {DateTime.Now}");

        return message;
    }

    public async Task<string> GetUserAccountRegisterTokenFromGoogleAuthCode(
        string authCode,
        [Service] IUserAccountService userAccountService)
    {
        return await userAccountService.GetUserAccountRegisterTokenByGoogleAuthCode(authCode);
    }

    public Book GetBook() => new()
    {
        Title = "C# in Depth",
        Author = "Jon Skeet"
    };
}

public class Book
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
}
