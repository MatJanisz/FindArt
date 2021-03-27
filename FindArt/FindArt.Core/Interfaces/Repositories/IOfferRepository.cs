using FindArt.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindArt.Core.Interfaces.Repositories
{
	public interface IOfferRepository
	{
		Task<IEnumerable<Offer>> GetAllOffersAsync(bool trackChanges);
		Task<Offer> GetOfferAsync(string id, bool trackChanges);
	}
}
