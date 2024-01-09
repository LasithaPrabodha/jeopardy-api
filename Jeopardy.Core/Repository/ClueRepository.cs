using Jeopardy.Core.Data;
using Jeopardy.Core.Interfaces;
using Jeopardy.Core.Models;
using Jeopardy.Core.Repository.Extensions;
using Jeopardy.Shared;
using Microsoft.EntityFrameworkCore;

namespace Jeopardy.Core.Repository;

public class ClueRepository(DataContext dataContext) : RepositoryBase<Clue>(dataContext), IClueRepository
{
    public async Task<bool> ClueExists(int clueId)
    {
        return await Exists(x => x.Id == clueId);
    }

    public async Task<Clue> GetClueAsync(int clueId, bool trackChanges)
    {
        return await FindByCondition(x => x.Id == clueId, trackChanges)
            .Include(c => c.IdNavigation)
            .Include(c => c.GameNavigation)
            .FirstAsync();
    }

    public async Task<Clue> GetRandomClueAsync(RandomClueParameters randomClueParameters, bool trackChanges)
    {

        var clues = FindAll(trackChanges);

        if (randomClueParameters.Value != 0)
            clues = clues.Where(c => c.Value == randomClueParameters.Value);

        if (randomClueParameters.Round != 0)
            clues = clues.Where(c => c.Round == randomClueParameters.Round);

        return await clues
            .Include(c => c.IdNavigation)
            .Include(c => c.GameNavigation)
            .Shuffle(true)
            .FirstAsync();
    }

    public async Task<PagedList<Clue>> GetCluesAsync(ClueParameters clueParameters, bool trackChanges)
    {
        var clues = FindAll(trackChanges)
                        .Include(c => c.IdNavigation)
                        .Search(clueParameters.SearchTerm ?? "")
                        .Sort(clueParameters.OrderBy ?? "");

        return await PagedList<Clue>
            .ToPagedList(clues, clueParameters.PageNumber, clueParameters.PageSize);
    }
}