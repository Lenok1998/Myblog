using MyBlog.DalContracts;

namespace MyBlog.SqlDal
{
    public class SqlUsersDao : IUsersDao
    {
        public bool IsExists(string login, string password)
        {
            // work with db
            return true;
        }
    }
}
