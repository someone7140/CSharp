namespace NovelManagementApi.src.service;

using NovelManagementApi.src.model.graphql;
using NovelManagementApi.src.repository;

public interface INovelService
{
    public List<NovelResponse> GetNovelsByUserAccountId(string userAccountId);
    public bool AddNovel(string title, string? description, string userAccountId);
    public bool EditNovel(string id, string title, string? description, string userAccountId);
    public bool DeleteNovel(string id, string userAccountId);
}

public class NovelService(
    INovelRepository _novelRepository,
    INovelSettingRepository _novelSettingRepository,
    INovelContentsRepository _novelContentsRepository
    ) : INovelService
{

    private readonly INovelRepository novelRepository = _novelRepository;
    private readonly INovelSettingRepository novelSettingRepository = _novelSettingRepository;
    private readonly INovelContentsRepository novelContentsRepository = _novelContentsRepository;

    // ユーザーの小説リストの取得
    public List<NovelResponse> GetNovelsByUserAccountId(string userAccountId)
    {
        var entities = novelRepository.GetNovelEntitiesByUserAccountId(userAccountId);

        return entities.Select(ent => new NovelResponse()
        {
            Id = ent.Id,
            Title = ent.Title,
            Description = ent.Description
        }).ToList();
    }

    // 小説の新規登録
    public bool AddNovel(string title, string? description, string userAccountId)
    {
        var id = Guid.CreateVersion7().ToString();
        novelRepository.AddNovelEntity(id, title, description, userAccountId);
        return true;
    }

    // 小説の編集
    public bool EditNovel(string id, string title, string? description, string userAccountId)
    {
        novelRepository.EditNovelEntity(id, title, description, userAccountId);
        return true;
    }

    // 小説の削除
    public bool DeleteNovel(string id, string userAccountId)
    {
        novelContentsRepository.DeleteNovelContentsEntityById(id, userAccountId);
        novelSettingRepository.DeleteNovelSettingEntityByNovelId(id, userAccountId);
        novelRepository.DeleteNovelEntity(id, userAccountId);
        return true;
    }
}
