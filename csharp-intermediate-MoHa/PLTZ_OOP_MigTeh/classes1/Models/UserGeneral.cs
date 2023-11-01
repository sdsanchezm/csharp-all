
using classes1.Interfaces;
using System.Text;


namespace classes1.Models
{
    class UserGeneral : UserAdmin, IUser
    {
        private string _name;
        public override string name 
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value.Trim();
            }
        
        }

        private string _SecretIdentityUsername;
        public string SecretIdentityUsername
        {
            get
            {
                return $"{name} ({_SecretIdentityUsername})";
            }
            set
            {
                _SecretIdentityUsername = value;
            }
        }

        private string _username;
        public string username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value.Trim();
            }
        }

        public int userid { get; set; }
        public bool isAdmin;
        public double location1;
        public List<PowerOfUser> UserPower;

        public UserGeneral() 
        { 
            userid = 1;
            isAdmin = false;
            UserPower = new List<PowerOfUser>();
        }

        public void UsePowers()
        {
            UserPower.ForEach(item => 
            {
                Console.WriteLine($"Power: {item.name} - ok");
            });
        }

        public void UsePowers2()
        {
            foreach(var item in UserPower)
            {
                Console.WriteLine($"{username} power: {item.name} - ok2");
            }
        }

        public string PrintAllPowers()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in UserPower)
            {
                sb.AppendLine($"{SecretIdentityUsername} power: {item.name} - from PrintAllPowers");
            }

            return sb.ToString();
        }

        public override string SaveTheWorld()
        {
            //throw new NotImplementedException();
            return $"{SecretIdentityUsername} is {username} and has saved the world!";
        }

        public override string SaveMars()
        {
            //return base.SaveMars();
            return $"{name} ({SecretIdentityUsername}) has saved Mars from UserGeneral!";
        }
    }

}
