using DesafioHandcom.Data;
using DesafioHandcom.Server.Interface;

namespace DesafioHandcom.Server.Repository
{
	public class UserRepository : IUser
	{
		private readonly AppDbContext _appDbContext;
		public UserRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public UserModel GetAuthorById(int id)
		{
			return _appDbContext.Users.FirstOrDefault(x => x.Id == id);
		}
	}
}
