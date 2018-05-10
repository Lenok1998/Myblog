namespace MyBlog.LogicContracts
{
    public interface IAuthLogic
    {
        bool CanAuthenticate(string login, string password);
    }
}
