using MyBlog.CoreLogic;
using MyBlog.DalContracts;
using MyBlog.LogicContracts;
using MyBlog.SqlDal;
using Ninject;

namespace MyBlog.Configuration
{
    public class DI
    {
        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAuthLogic>().To<AuthLogic>();
            kernel.Bind<IUsersDao>().To<SqlUsersDao>();
        }
    }
}
