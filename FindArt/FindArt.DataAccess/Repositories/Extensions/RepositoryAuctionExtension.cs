using FindArt.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace FindArt.DataAccess.Repositories.Extensions
{
    public static class RepositoryAuctionExtensions
    {
        public static IQueryable<Auction> Sort(this IQueryable<Auction> products, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return products.OrderBy(e => e.DueDate);
            }

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Auction>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                return products.OrderBy(e => e.DueDate);
            }

            return products.OrderBy(orderQuery);
        }
    }
}
