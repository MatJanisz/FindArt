using FindArt.Core.DataTransferObjects.User;
using System.Threading.Tasks;

namespace FindArt.Core.Interfaces.Services
{
	public interface IAuthenticationService
	{
		Task<bool> ValidateUser(UserAuthenticationDto userForAuth);
	}
}
