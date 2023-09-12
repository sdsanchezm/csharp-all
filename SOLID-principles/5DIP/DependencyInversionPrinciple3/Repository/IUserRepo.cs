using DependencyInversionPrinciple3.Models;

namespace DependencyInversionPrinciple3.Repository
{
    public interface IUserRepo
    {
        void Add(User student);
        IEnumerable<User> GetAll();
    }
}