using System.Collections.ObjectModel;

namespace singleResponsibilityPrinciple
{
    public class UserStorage<T>
    {
        private ObservableCollection<T> _users;
        public UserStorage()
        {
            _users = new ObservableCollection<T>();
        }

        public T Add(T item)
        {
            _users.Add(item);
            return item;
        }

        public T Remove (T item)
        {
            _users.Remove(item);
            return item;
        }

        public IEnumerable<T> GetAll()
        {
            return _users;
        }
    }
}
