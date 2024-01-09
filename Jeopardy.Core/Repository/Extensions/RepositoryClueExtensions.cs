using System.Linq.Dynamic.Core;
using Jeopardy.Core.Models;
using Jeopardy.Core.Repository.Utility;

namespace Jeopardy.Core.Repository.Extensions;

public static class RepositoryClueExtensions
{
    public static IQueryable<Clue> Search(this IQueryable<Clue> clues, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return clues;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        return clues.Where(e => e.IdNavigation.Clue != null && e.IdNavigation.Clue.Contains(lowerCaseTerm, StringComparison.CurrentCultureIgnoreCase));
    }

    public static IQueryable<Clue> Sort(this IQueryable<Clue> clues, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return clues.OrderBy(e => e.Id);

        var orderQuery = OrderQueryBuilder.CreateOrderQuery<Clue>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return clues.OrderBy(e => e.Id);

        return clues.OrderBy(orderQuery);
    }

     public static IQueryable<Clue> Shuffle(this IQueryable<Clue> clues, bool randomize)
    {
        if(!randomize)
            return clues;

        Random rand = new();
        int skipper = rand.Next(0, clues.Count());

        return clues.Skip(skipper);
    }
}