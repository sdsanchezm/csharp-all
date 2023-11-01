using classes1.Models;

namespace classes1
{
    partial class Program
    {
        static void Main(String[] args)
        {

            PowerOfUser FlyPower = new PowerOfUser();
            FlyPower.name = "Fly";
            FlyPower.description = "Fly high";
            FlyPower.Level = powerLevel.third;

            var ForcePower = new PowerOfUser();
            ForcePower.name = "Force";
            ForcePower.description = "unnatural Strenght";
            ForcePower.Level = powerLevel.second;

            var BreathInWater = new PowerOfUser();
            BreathInWater.name = "BreatInWater";
            BreathInWater.description = "ability to breath in water";
            BreathInWater.Level = powerLevel.first;

            UserGeneral person1 = new UserGeneral();

            person1.name = "  James Sanc   ";
            person1.userid = 21;
            person1.username = "   jamecho   ";

            var ListOfPowersPerson1 = new List<PowerOfUser>();
            List<PowerOfUser> ListOfPowersPerson2 = new List<PowerOfUser>(); // different way to define it
            ListOfPowersPerson1.Add(FlyPower);
            ListOfPowersPerson1.Add(ForcePower);

            person1.UserPower = ListOfPowersPerson1;
            //person1.UserPower.Add(ForcePower);// this can be done because the constructor created a List<T> already

            Console.WriteLine($"{person1.name} - {person1.username} - {person1.userid} ");

            person1.UsePowers();
            person1.UsePowers2();

            Console.WriteLine(person1.PrintAllPowers());

            

            //var record1 = new UserGeneralRecord(id: 2, name: "jara", isActive: false);
            //var record2 = new UserGeneralRecord(id: 2, name: "jara", isActive: false);
            //Console.WriteLine(record1 == record2); // True


            //// this is a record
            //public record UserGeneralRecord(int id, string name, bool isActive);

            var student1 = new UserStudent();
            student1.username = "Amparo21";
            student1.name = "Amparo Sanc";
            student1.userid = 42;
            student1.SecretIdentityUsername = "oiuqewr";
            student1.UserPower.Add(BreathInWater);
            student1.UserPower.Add(FlyPower);

            Console.WriteLine(student1.PrintAllPowers());
            Console.WriteLine(student1.StudentActivity("walk"));

            string resultSaveTheWorld = student1.SaveTheWorld();
            Console.WriteLine(resultSaveTheWorld);

            Console.WriteLine(student1.SaveMars());

            var printInfo = new PrintInterface();
            printInfo.PrintInterfaceIUser(student1);
            printInfo.PrintInterfaceIUser(person1);


            // csc -langversion:?
            //Console.Write(typeof(string).Assembly.ImageRuntimeVersion);



        }
    }
}
