namespace NovelManagementApi.src.repository;

using NovelManagementApi.src.model.db;

public interface IUserAccountRepository
{
    public UserAccountEntity? GetUserAccountByGmail(string gmail);
    public UserAccountEntity? GetUserAccountByUserSettingId(string gmail);
    public void AddUserAccountEntity(
        string id,
        string name,
        string gmail,
        string userSettingId,
        string imageUrl
    );
}

public class UserAccountRepository(ApplicationDbContext _context) : IUserAccountRepository
{
    private readonly ApplicationDbContext dbContext = _context;

    public UserAccountEntity? GetUserAccountByGmail(string gmail)
    {
        return dbContext.UserAccounts.FirstOrDefault(u => u.Gmail == gmail);
    }

    public UserAccountEntity? GetUserAccountByUserSettingId(string userSettingId)
    {
        return dbContext.UserAccounts.FirstOrDefault(u => u.UserSettingId == userSettingId);
    }

    public void AddUserAccountEntity(
        string id,
        string name,
        string gmail,
        string userSettingId,
        string imageUrl
    )
    {
        var entity = new UserAccountEntity()
        {
            Id = id,
            Name = name,
            UserSettingId = userSettingId,
            Gmail = gmail,
            ImageUrl = imageUrl,
            CreatedAt = DateTimeOffset.UtcNow
        };
        dbContext.UserAccounts.Add(entity);
        dbContext.SaveChanges();
    }
}
