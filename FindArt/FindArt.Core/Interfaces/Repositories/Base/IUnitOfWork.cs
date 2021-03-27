using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindArt.Core.Interfaces.Repositories.Base
{
	public interface IUnitOfWork
	{
		IAuctionRepository Auction { get; }
		IOfferRepository Offer { get; }
		IProductRepository Product { get; }
		Task SaveAsync();
	}
}
