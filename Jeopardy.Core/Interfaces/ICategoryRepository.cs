using Jeopardy.Core.Models;
using Jeopardy.Core.Repository;
using Jeopardy.Shared;

namespace Jeopardy.Core.Interfaces;
public interface ICategoryRepository
{
    Task<PagedList<Category>> GetCategoriesAsync(CategoryParameters categoryParameters, bool trackChanges);
    Task<Category> GetCategoryAsync(int categoryId, bool trackChanges);
    Task<bool> CategoryExists(int categoryId);
}