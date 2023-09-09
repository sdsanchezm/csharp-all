namespace singleResponsibilityPrinciple
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            UserRepo userRepository = new();
            var userRepository2 = new UserRepo();
            //userRepo.Export();  
            //ExportHelper.ExportCSV(userRepository.GetAllUsers());

            //ExportCSVGeneric1<UserRepo>.Export(userRepository.GetAllUsers());

            //var export2 = new ExportHelper2<UserRepo>();
            ExportHelper2<User> userExport = new();
            userExport.ExportToCSV2(userRepository.GetAllUsers());
            //export2.ExportToCSV2(userRepository.GetAllUsers());

            Console.WriteLine(typeof(UserRepo));
            //Console.WriteLine(typeof(userRepository2));

            Console.WriteLine("Process completed...");
        }
    }
}