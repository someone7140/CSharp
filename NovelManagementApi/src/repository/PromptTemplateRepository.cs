namespace NovelManagementApi.src.repository;

using Microsoft.EntityFrameworkCore;
using NovelManagementApi.src.model.db;

public interface IPromptTemplateRepository
{
    public void AddPromptTemplateEntity(
        string id,
        string name,
        int? displayOrder,
        string? template,
        string? description,
        string userAccountId
    );
    public void EditPromptTemplateEntity(
        string id,
        string name,
        int? displayOrder,
        string? template,
        string? description,
        string userAccountId
    );
    public void DeletePromptTemplateEntity(string id, string ownerUserAccountId);
    public PromptTemplateEntity? GetPromptTemplateById(string id, string ownerUserAccountId);
    public List<PromptTemplateEntity> GetPromptTemplates(string ownerUserAccountId);
}

public class PromptTemplateRepository(ApplicationDbContext _context) : IPromptTemplateRepository
{
    private readonly ApplicationDbContext dbContext = _context;

    public void AddPromptTemplateEntity(
        string id,
        string name,
        int? displayOrder,
        string? template,
        string? description,
        string ownerUserAccountId
    )
    {
        var entity = new PromptTemplateEntity
        {
            Id = id,
            Name = name,
            OwnerUserAccountId = ownerUserAccountId,
            DisplayOrder = displayOrder,
            Template = template,
            Description = description
        };
        dbContext.PromptTemplates.Add(entity);
        dbContext.SaveChanges();
    }

    public void EditPromptTemplateEntity(
        string id,
        string name,
        int? displayOrder,
        string? template,
        string? description,
        string ownerUserAccountId
    )
    {
        dbContext.PromptTemplates
           .Where(t => t.Id == id && t.OwnerUserAccountId == ownerUserAccountId)
           .ExecuteUpdate(setters =>
                setters.SetProperty(t => t.Name, name)
                       .SetProperty(t => t.DisplayOrder, displayOrder)
                       .SetProperty(t => t.Template, template)
                       .SetProperty(t => t.Description, description)
           );
    }

    public void DeletePromptTemplateEntity(string id, string ownerUserAccountId)
    {
        dbContext.PromptTemplates
           .Where(t => t.Id == id && t.OwnerUserAccountId == ownerUserAccountId)
           .ExecuteDelete();
    }

    public PromptTemplateEntity? GetPromptTemplateById(string id, string ownerUserAccountId)
    {
        return dbContext.PromptTemplates.FirstOrDefault(t => t.Id == id && t.OwnerUserAccountId == ownerUserAccountId);
    }

    public List<PromptTemplateEntity> GetPromptTemplates(string ownerUserAccountId)
    {
        return dbContext.PromptTemplates.Where(t => t.OwnerUserAccountId == ownerUserAccountId).ToList();
    }
}
