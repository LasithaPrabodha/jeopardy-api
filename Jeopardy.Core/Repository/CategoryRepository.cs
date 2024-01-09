using Jeopardy.Core.Data;
using Jeopardy.Core.Interfaces;
using Jeopardy.Core.Models;
using Jeopardy.Core.Repository.Extensions;
using Jeopardy.Core.Shared;
using Microsoft.EntityFrameworkCore;

namespace Jeopardy.Core.Repository;

public class CategoryRepository(DataContext dataContext) : RepositoryBase<Category>(dataContext), ICategoryRepository
{
    public async Task<ICollection<Category>> GetCategoriesAsync(CategoryParameters categoryParameters, bool trackChanges)
    {
        var employees = await FindAll(trackChanges)
               .Search(categoryParameters.SearchTerm)
               .Sort(categoryParameters.OrderBy)
               .ToListAsync();

        return PagedList<Category>
            .ToPagedList(employees, categoryParameters.PageNumber, categoryParameters.PageSize);
    }


}