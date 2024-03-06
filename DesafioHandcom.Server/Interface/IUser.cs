namespace DesafioHandcom.Server.Interface
{
	public interface IUser
	{
		public UserModel GetAuthorById(int id);
		List<UserModel> GetAllAuthors();
	}
}
