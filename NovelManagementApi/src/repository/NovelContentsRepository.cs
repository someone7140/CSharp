namespace NovelManagementApi.src.repository;

using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using NovelManagementApi.src.model.db;

public interface INovelContentsRepository
{
    public List<NovelContentsEntity> GetNovelContentsByContentsIds(string[] ids, string userAccountId);
    public List<NovelContentsEntity> GetNovelContentsByNovelId(string contentsId, string userAccountId);
    public void RegisterNovelContentsEntities(List<NovelContentsEntity> contentsList);
    public void DeleteNovelContentsEntityById(string id, string ownerUserAccountId);
    public void DeleteNovelContentsEntityByIds(string[] ids, string ownerUserAccountId);
    public void DeleteNovelContentsEntityByNovelId(string novelId, string ownerUserAccountId);
    public void UpdateContentsParentIdNull(string[] parentContentsIds, string ownerUserAccountId);
}

public class NovelContentsRepository(ApplicationDbContext _context) : INovelContentsRepository
{
    private readonly ApplicationDbContext dbContext = _context;

    public List<NovelContentsEntity> GetNovelContentsByContentsIds(string[] ids, string userAccountId)
    {
        return dbContext.NovelContents
            .Where(contents => ids.Contains(contents.Id) && contents.OwnerUserAccountId == userAccountId)
            .OrderBy(contents => contents.DisplayOrder == null ? int.MaxValue : contents.DisplayOrder)
            .ToList();
    }

    public List<NovelContentsEntity> GetNovelContentsByNovelId(string novelId, string userAccountId)
    {
        return dbContext.NovelContents
            .Where(contents => contents.NovelId == novelId && contents.OwnerUserAccountId == userAccountId)
            .OrderBy(contents => contents.DisplayOrder == null ? int.MaxValue : contents.DisplayOrder)
            .ToList();
    }

    public void RegisterNovelContentsEntities(List<NovelContentsEntity> contentsList)
    {
        dbContext.BulkInsertOrUpdate(contentsList);
    }

    public void DeleteNovelContentsEntityById(string id, string ownerUserAccountId)
    {
        dbContext.NovelContents
           .Where(n => n.Id == id && n.OwnerUserAccountId == ownerUserAccountId)
           .ExecuteDelete();
    }

    public void DeleteNovelContentsEntityByIds(string[] ids, string ownerUserAccountId)
    {
        dbContext.NovelContents
           .Where(n => ids.Contains(n.Id) && n.OwnerUserAccountId == ownerUserAccountId)
           .ExecuteDelete();
    }

    public void DeleteNovelContentsEntityByNovelId(string novelId, string ownerUserAccountId)
    {
        dbContext.NovelContents
           .Where(n => n.NovelId == novelId && n.OwnerUserAccountId == ownerUserAccountId)
           .ExecuteDelete();
    }

    public void UpdateContentsParentIdNull(string[] parentContentsIds, string ownerUserAccountId)
    {
        dbContext.NovelContents
           .Where(n => parentContentsIds.Contains(n.ParentContentsId) && n.OwnerUserAccountId == ownerUserAccountId)
           .ExecuteUpdate(setters =>
                setters.SetProperty(n => n.ParentContentsId, (string?)null)
           );
    }
}
