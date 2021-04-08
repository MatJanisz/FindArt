using FindArt.Core.DataTransferObjects.User.Base;

namespace FindArt.Core.DataTransferObjects.User
{
	public class UserRegistrationDto : UserBaseDto
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
