using DependencyInversionPrinciple3.Models;
using System.Collections.ObjectModel;

namespace DependencyInversionPrinciple3.Repository
{
    public class UserRepo : IUserRepo
    {
        private static ObservableCollection<User> _collection;

        public UserRepo()
        {
            InitData();
        }

        private void InitData()
        {
            if (_collection == null)
            {
                _collection = new();
                _collection.Add(new User(1, "Jamecho", new List<double>() { 1, 2.5 }));
                _collection.Add(new User(2, "Jara", new List<double>() { 2, 3 }));
                _collection.Add(new User(3, "Tiche Maria", new List<double>() { 4.8, 3.9 }));
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _collection;
        }

        public void Add(User student)
        {
            _collection.Add(student);
        }
    }
}
