using MyBlog.DalContracts;
using MyBlog.LogicContracts;

namespace MyBlog.CoreLogic
{
    public class AuthLogic : IAuthLogic
    {
        private readonly IUsersDao _usersDao;

        public AuthLogic(IUsersDao usersDao)
        {
            _usersDao = usersDao;
        }

        public bool CanAuthenticate(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                return false;
            }

            if (password == null)
            {
                return false;
            }

            return _usersDao.IsExists(login, password);
        }
    }
}

