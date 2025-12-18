namespace NovelManagementApi.src.repository;

using NovelManagementApi.src.model.db;

public interface IUserAccountRepository
{
    public UserAccountEntity? GetUserAccountByGmail(string gmail);
}

public class UserAccountRepository(ApplicationDbContext _context) : IUserAccountRepository
{
    private readonly ApplicationDbContext dbContext = _context;

    public UserAccountEntity? GetUserAccountByGmail(string gmail)
    {
        return dbContext.UserAccounts.FirstOrDefault(u => u.Gmail == gmail);
    }
}
