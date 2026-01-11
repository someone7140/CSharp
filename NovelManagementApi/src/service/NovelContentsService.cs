namespace NovelManagementApi.src.service;

using NovelManagementApi.src.model.db;
using NovelManagementApi.src.model.graphql;
using NovelManagementApi.src.repository;

public interface INovelContentsService
{
    public List<NovelContentsResponse> GetNovelContentsByNovelId(string novelId, string userAccountId);
    public bool RegisterNovelContents(NovelContentsRegisterRequest[] inputs, string userAccountId);
    public bool DeleteNovelContentsById(string contentsId, string userAccountId);
    public bool DeleteNovelContentsByIds(string[] contentsIds, string userAccountId);
}

public class NovelContentsService(INovelContentsRepository _novelContentsRepository) : INovelContentsService
{

    private readonly INovelContentsRepository novelContentsRepository = _novelContentsRepository;

    // 指定した小説の文章の一覧
    public List<NovelContentsResponse> GetNovelContentsByNovelId(string novelId, string userAccountId)
    {
        var entities = novelContentsRepository.GetNovelContentsByNovelId(novelId, userAccountId);
        return entities.Select(entity => new NovelContentsResponse()
        {
            Id = entity.Id,
            ChapterName = entity.ChapterName,
            NovelId = entity.NovelId,
            ParentContentsId = entity.ParentContentsId,
            DisplayOrder = entity.DisplayOrder,
            Contents = entity.Contents,
            Description = entity.Description,
        }).ToList();
    }

    // 小説の文章登録
    public bool RegisterNovelContents(NovelContentsRegisterRequest[] requests, string userAccountId)
    {
        var reqIds = requests.Where(req => req.Id is not null).Select(req => req.Id!).ToArray();
        var mySettings = novelContentsRepository.GetNovelContentsByContentsIds(reqIds, userAccountId);
        var entities = requests
            .Where(req => req.Id == null || mySettings.Any(setting => setting.OwnerUserAccountId == userAccountId))
            .Select(req => new NovelContentsEntity()
            {
                Id = req.Id ?? Guid.CreateVersion7().ToString(),
                ChapterName = req.ChapterName,
                NovelId = req.NovelId,
                OwnerUserAccountId = userAccountId,
                ParentContentsId = req.ParentContentsId,
                DisplayOrder = req.DisplayOrder,
                Contents = req.Contents,
                Description = req.Description,
            }).ToList();

        if (entities.Count > 0)
        {

            novelContentsRepository.RegisterNovelContentsEntities(entities);
        }

        return true;
    }

    // 小説文章のID指定削除
    public bool DeleteNovelContentsById(string contentsId, string userAccountId)
    {
        novelContentsRepository.UpdateContentsParentIdNull([contentsId], userAccountId);
        novelContentsRepository.DeleteNovelContentsEntityById(contentsId, userAccountId);
        return true;
    }

    // 小説設定のID指定削除（複数指定）
    public bool DeleteNovelContentsByIds(string[] contentsIds, string userAccountId)
    {
        novelContentsRepository.UpdateContentsParentIdNull(contentsIds, userAccountId);
        novelContentsRepository.DeleteNovelContentsEntityByIds(contentsIds, userAccountId);
        return true;
    }
}
