namespace NovelManagementApi.src.service;

using NovelManagementApi.src.model.db;
using NovelManagementApi.src.model.graphql;
using NovelManagementApi.src.repository;

public interface INovelSettingService
{
    public List<NovelSettingResponse> GetNovelSettingsByNovelId(string novelId, string userAccountId);
    public List<NovelSettingResponse> GetNovelSettingsByParentSettingId(string parentSettingId, string userAccountId);
    public bool RegisterNovelSettings(NovelSettingRegisterRequest[] inputs, string userAccountId);
    public bool DeleteNovelSettingById(string settingId, string userAccountId);
    public bool DeleteNovelSettingByIds(string[] settingIds, string userAccountId);
}

public class NovelSettingService(INovelSettingRepository _novelSettingRepository) : INovelSettingService
{

    private readonly INovelSettingRepository novelSettingRepository = _novelSettingRepository;

    // 指定した小説の設定の一覧
    public List<NovelSettingResponse> GetNovelSettingsByNovelId(string novelId, string userAccountId)
    {
        var entities = novelSettingRepository.GetNovelSettingsByNovelId(novelId, userAccountId);
        return entities.Select(entity => new NovelSettingResponse()
        {
            Id = entity.Id,
            Name = entity.Name,
            NovelId = entity.NovelId,
            ParentSettingId = entity.ParentSettingId,
            DisplayOrder = entity.DisplayOrder,
            Attributes = entity.Attributes,
            Description = entity.Description,
        }).ToList();
    }

    // 指定した親の設定の一覧
    public List<NovelSettingResponse> GetNovelSettingsByParentSettingId(string parentSettingId, string userAccountId)
    {
        var entities = novelSettingRepository.GetNovelSettingsByParentSettingId(parentSettingId, userAccountId);
        return entities.Select(entity => new NovelSettingResponse()
        {
            Id = entity.Id,
            Name = entity.Name,
            NovelId = entity.NovelId,
            ParentSettingId = entity.ParentSettingId,
            DisplayOrder = entity.DisplayOrder,
            Attributes = entity.Attributes,
            Description = entity.Description,
        }).ToList();
    }

    // 小説の設定登録
    public bool RegisterNovelSettings(NovelSettingRegisterRequest[] requests, string userAccountId)
    {
        var reqIds = requests.Where(req => req.Id is not null).Select(req => req.Id!).ToArray();
        var mySettings = reqIds.Length == 0 ? [] : novelSettingRepository.GetNovelSettingsBySettingIds(
            requests.Where(req => req.Id is not null).Select(req => req.Id!).ToArray(), userAccountId);
        var entities = requests
            .Where(req => req.Id == null || mySettings.Any(setting => setting.OwnerUserAccountId == userAccountId))
            .Select(req => new NovelSettingEntity()
            {
                Id = req.Id ?? Guid.CreateVersion7().ToString(),
                Name = req.Name,
                NovelId = req.NovelId,
                OwnerUserAccountId = userAccountId,
                ParentSettingId = req.ParentSettingId,
                DisplayOrder = req.DisplayOrder,
                Attributes = req.Attributes,
                Description = req.Description,
            }).ToList();

        if (entities.Count > 0)
        {

            novelSettingRepository.RegisterNovelSettingEntities(entities);
        }

        return true;
    }

    // 小説設定のID指定削除
    public bool DeleteNovelSettingById(string settingId, string userAccountId)
    {
        novelSettingRepository.UpdateSettingParentIdNull([settingId], userAccountId);
        novelSettingRepository.DeleteNovelSettingEntityById(settingId, userAccountId);
        return true;
    }

    // 小説設定のID指定削除（複数指定）
    public bool DeleteNovelSettingByIds(string[] settingIds, string userAccountId)
    {
        novelSettingRepository.UpdateSettingParentIdNull(settingIds, userAccountId);
        novelSettingRepository.DeleteNovelSettingEntityByIds(settingIds, userAccountId);
        return true;
    }
}
