namespace NovelManagementApi.src.repository;

using Microsoft.EntityFrameworkCore;
using NovelManagementApi.src.model.db;

public interface INovelRepository
{
    public List<NovelEntity> GetNovelEntitiesByUserAccountId(string userAccountId);

    public void AddNovelEntity(
        string id,
        string title,
        string? description,
        string ownerUserAccountId
    );

    public void EditNovelEntity(
        string id,
        string title,
        string? description,
        string ownerUserAccountId
    );

    public void DeleteNovelEntity(string id, string ownerUserAccountId);
}

public class NovelRepository(ApplicationDbContext _context) : INovelRepository
{
    private readonly ApplicationDbContext dbContext = _context;

    public List<NovelEntity> GetNovelEntitiesByUserAccountId(string userAccountId)
    {
        return dbContext.Novels.Where(n => n.OwnerUserAccountId == userAccountId).OrderByDescending(n => n.CreatedAt).ToList();
    }

    public void AddNovelEntity(
        string id,
        string title,
        string? description,
        string ownerUserAccountId
    )
    {
        var entity = new NovelEntity()
        {
            Id = id,
            Title = title,
            OwnerUserAccountId = ownerUserAccountId,
            Description = description,
            CreatedAt = DateTimeOffset.UtcNow
        };
        dbContext.Novels.Add(entity);
        dbContext.SaveChanges();
    }

    public void EditNovelEntity(
        string id,
        string title,
        string? description,
        string ownerUserAccountId
    )
    {
        dbContext.Novels
           .Where(n => n.Id == id && n.OwnerUserAccountId == ownerUserAccountId)
           .ExecuteUpdate(setters =>
                setters.SetProperty(n => n.Title, title)
                       .SetProperty(n => n.Description, description)
           );

    }

    public void DeleteNovelEntity(string id, string ownerUserAccountId)
    {
        dbContext.Novels
           .Where(n => n.Id == id && n.OwnerUserAccountId == ownerUserAccountId)
           .ExecuteDelete();
    }
}
