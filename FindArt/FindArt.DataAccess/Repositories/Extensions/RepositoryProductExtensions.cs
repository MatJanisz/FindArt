using FindArt.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace FindArt.DataAccess.Repositories.Extensions
{
	public static class RepositoryProductExtensions
	{
        public static IQueryable<Product> Sort(this IQueryable<Product> products, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
			{
                return products.OrderBy(e => e.Name);
            }

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Product>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
			{
                return products.OrderBy(e => e.Name);
            }

            return products.OrderBy(orderQuery);
        }
    }
}
