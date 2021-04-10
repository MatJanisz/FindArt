using FindArt.Core.Models;
using FindArt.Core.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindArt.Core.Interfaces.Repositories
{
	public interface IAuctionRepository
	{
		Task<PagedList<Auction>> GetAllAuctionsAsync(AuctionParameters auctionParameters, bool trackChanges);
		Task<Auction> GetAuctionAsync(string id, bool trackChanges);
		public void CreateAuction(Auction auction);

		public void DeleteAuction(Auction auction);

		public void UpdateAuction(Auction auction);
	}
}
