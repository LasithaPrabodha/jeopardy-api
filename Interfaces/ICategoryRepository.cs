using JeopardyAPI.Models;

namespace JeopardyAPI.Interfaces;
public interface ICategoryRepository
{
    ICollection<Category> GetCategories();
    Category GetCategory(int id);
    ICollection<Clue> GetClueByCategory(int categoryId);
    bool CategoryExists(int id);
    bool CreateCategory(Category category);
    bool UpdateCategory(Category category);
    bool DeleteCategory(Category category);
    bool Save();
}