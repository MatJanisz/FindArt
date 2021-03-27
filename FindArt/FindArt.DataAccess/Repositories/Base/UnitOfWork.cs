using FindArt.Core.Interfaces.Repositories;
using FindArt.Core.Interfaces.Repositories.Base;
using System.Threading.Tasks;

namespace FindArt.DataAccess.Repositories.Base
{
	public class UnitOfWork : IUnitOfWork
	{
		private FindArtDbContext _context;
		private IAuctionRepository _auctionRepository;
		private IOfferRepository _offerRepository;
		private IProductRepository _productRepository;
		public IAuctionRepository Auction => _auctionRepository ??= new AuctionRepository(_context);

		public IOfferRepository Offer => _offerRepository ??= new OfferRepository(_context);

		public IProductRepository Product => _productRepository ??= new ProductRepository(_context);

		public Task SaveAsync() => _context.SaveChangesAsync();
	}
}
