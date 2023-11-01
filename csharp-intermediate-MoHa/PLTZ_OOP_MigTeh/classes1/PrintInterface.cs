
using classes1.Interfaces;

namespace classes1
{
    internal class PrintInterface
    {
        public void PrintInterfaceIUser(IUser user)
        {
            //Console.WriteLine($"userid: {user.userid}");
            //Console.WriteLine($"secret Identity: {user.SecretIdentityUsername}");
            //Console.WriteLine($"name: {user.name}");
            Console.WriteLine(user.GetAllInfo());
        }
    }

}
