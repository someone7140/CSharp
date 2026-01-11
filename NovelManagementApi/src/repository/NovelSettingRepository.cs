namespace NovelManagementApi.src.repository;

using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using NovelManagementApi.src.model.db;

public interface INovelSettingRepository
{
    public List<NovelSettingEntity> GetNovelSettingsBySettingIds(string[] ids, string userAccountId);
    public List<NovelSettingEntity> GetNovelSettingsByNovelId(string novelId, string userAccountId);
    public List<NovelSettingEntity> GetNovelSettingsByParentSettingId(string parentSettingId, string userAccountId);
    public void RegisterNovelSettingEntities(List<NovelSettingEntity> settings);
    public void DeleteNovelSettingEntityById(string id, string ownerUserAccountId);
    public void DeleteNovelSettingEntityByIds(string[] ids, string ownerUserAccountId);
    public void DeleteNovelSettingEntityByNovelId(string novelId, string ownerUserAccountId);
    public void UpdateSettingParentIdNull(string[] parentSettingIds, string ownerUserAccountId);
}

public class NovelSettingRepository(ApplicationDbContext _context) : INovelSettingRepository
{
    private readonly ApplicationDbContext dbContext = _context;

    public List<NovelSettingEntity> GetNovelSettingsBySettingIds(string[] ids, string userAccountId)
    {
        return dbContext.NovelSettings
            .Where(setting => ids.Contains(setting.Id) && setting.OwnerUserAccountId == userAccountId)
            .OrderBy(setting => setting.DisplayOrder == null ? int.MaxValue : setting.DisplayOrder)
            .ToList();
    }

    public List<NovelSettingEntity> GetNovelSettingsByNovelId(string novelId, string userAccountId)
    {
        return dbContext.NovelSettings
            .Where(setting => setting.NovelId == novelId && setting.OwnerUserAccountId == userAccountId)
            .OrderBy(setting => setting.DisplayOrder == null ? int.MaxValue : setting.DisplayOrder)
            .ToList();
    }

    public List<NovelSettingEntity> GetNovelSettingsByParentSettingId(string parentSettingId, string userAccountId)
    {
        return dbContext.NovelSettings
            .Where(setting => setting.OwnerUserAccountId == userAccountId && setting.ParentSettingId == parentSettingId)
            .OrderBy(setting => setting.DisplayOrder == null ? int.MaxValue : setting.DisplayOrder)
            .ToList();
    }

    public void RegisterNovelSettingEntities(List<NovelSettingEntity> settings)
    {
        dbContext.BulkInsertOrUpdate(settings);
    }

    public void DeleteNovelSettingEntityById(string id, string ownerUserAccountId)
    {
        dbContext.NovelSettings
           .Where(n => n.Id == id && n.OwnerUserAccountId == ownerUserAccountId)
           .ExecuteDelete();
    }

    public void DeleteNovelSettingEntityByIds(string[] ids, string ownerUserAccountId)
    {
        dbContext.NovelSettings
           .Where(n => ids.Contains(n.Id) && n.OwnerUserAccountId == ownerUserAccountId)
           .ExecuteDelete();
    }

    public void DeleteNovelSettingEntityByNovelId(string novelId, string ownerUserAccountId)
    {
        dbContext.NovelSettings
           .Where(n => n.NovelId == novelId && n.OwnerUserAccountId == ownerUserAccountId)
           .ExecuteDelete();
    }

    public void UpdateSettingParentIdNull(string[] parentSettingIds, string ownerUserAccountId)
    {
        dbContext.NovelSettings
           .Where(n => parentSettingIds.Contains(n.ParentSettingId) && n.OwnerUserAccountId == ownerUserAccountId)
           .ExecuteUpdate(setters =>
                setters.SetProperty(n => n.ParentSettingId, (string?)null)
           );
    }
}
