

using System.Linq.Dynamic.Core;
using Jeopardy.Core.Models;
using Jeopardy.Core.Repository.Extensions.Utility;

namespace Jeopardy.Core.Repository.Extensions;

public static class RepositoryCategoryExtensions
	{
        public static IQueryable<Category> Search(this IQueryable<Category> categories, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return categories;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return categories.Where(e => e.CategoryName.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Category> Sort(this IQueryable<Category> categories, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return categories.OrderBy(e => e.CategoryName);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Category>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return categories.OrderBy(e => e.CategoryName);

            return categories.OrderBy(orderQuery);
        }
    }