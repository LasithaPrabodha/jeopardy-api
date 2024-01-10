using Jeopardy.Core.Data;
using Jeopardy.Core.Interfaces;
using Jeopardy.Core.Models;
using Jeopardy.Core.Repository.Extensions;
using Jeopardy.Shared;
using Microsoft.EntityFrameworkCore;

namespace Jeopardy.Core.Repository;

public class CategoryRepository(DataContext dataContext) : RepositoryBase<Category>(dataContext), ICategoryRepository
{
    public async Task<PagedList<Category>> GetCategoriesAsync(CategoryParameters categoryParameters, bool trackChanges)
    {
        var categories =
              FindAll(trackChanges)
               .Search(categoryParameters.SearchTerm ?? "")
               .Sort(categoryParameters.OrderBy ?? "")
               .Shuffle(categoryParameters.Randomize);

        return await PagedList<Category>
            .ToPagedList(categories, categoryParameters.PageNumber, categoryParameters.PageSize);
    }
    public async Task<Category> GetCategoryAsync(int categoryId, bool trackChanges)
    {
        var category = await FindByCondition(x => x.Id == categoryId, trackChanges).FirstAsync();

        return category;
    }
    public async Task<bool> CategoryExists(int categoryId)
    {
        return await Exists(x => x.Id == categoryId);
    }

    public async Task<Clue> GetRandomClueAsync(int categoryId, RandomClueParameters randomClueParameters, bool trackChanges)
    {
        var clues = FindByCondition(x => x.Id == categoryId, trackChanges)
                         .SelectMany(cat => cat.Clues)
                         .Include(c => c.IdNavigation)
                         .Include(c => c.GameNavigation)
                         .Include(c => c.Categories)
                         .Sort(randomClueParameters.OrderBy ?? "");

        if (randomClueParameters.Value != 0)
            clues = clues.Where(c => c.Value == randomClueParameters.Value);

        if (randomClueParameters.Round != 0)
            clues = clues.Where(c => c.Round == randomClueParameters.Round);

        return await clues.Shuffle(true).FirstAsync();
    }
}