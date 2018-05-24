namespace MyBlog.DalContracts
{
    public interface IUsersDao
    {
        bool IsExists(string login, string password);
    }
}
