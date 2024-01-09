using Jeopardy.Core.Models;
using Jeopardy.Core.Shared;

namespace Jeopardy.Core.Interfaces;
public interface ICategoryRepository
{
    Task<ICollection<Category>> GetCategoriesAsync(CategoryParameters categoryParameters, bool trackChanges);

}