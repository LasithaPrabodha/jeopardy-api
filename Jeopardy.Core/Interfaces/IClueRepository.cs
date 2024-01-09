using Jeopardy.Core.Models;
using Jeopardy.Core.Repository;
using Jeopardy.Shared;

namespace Jeopardy.Core.Interfaces;

public interface IClueRepository
{
    Task<PagedList<Clue>> GetCluesAsync(ClueParameters categoryParameters, bool trackChanges);
    Task<Clue> GetRandomClueAsync(RandomClueParameters randomClueParameters, bool trackChanges);
    Task<Clue> GetClueAsync(int categoryId, bool trackChanges);
    Task<bool> ClueExists(int categoryId);
}