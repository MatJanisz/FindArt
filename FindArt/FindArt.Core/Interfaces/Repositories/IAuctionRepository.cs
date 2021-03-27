using FindArt.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindArt.Core.Interfaces.Repositories
{
	public interface IAuctionRepository
	{
		void AssignProductToAuction(string productID, string auctionID);
		Task<IEnumerable<Auction>> GetAllAuctionsAsync(bool trackChanges);
		Task<Auction> GetAuctionAsync(string id, bool trackChanges);
	}
}
