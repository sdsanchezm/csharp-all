namespace singleResponsibilityPrinciple
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            UserRepo userRepository = new();
            //userRepo.Export();  
            //ExportHelper.ExportCSV(userRepository.GetAllUsers());

            ExportCSVGeneric1<UserRepo>.Export(userRepository.GetAllUsers());

            Console.WriteLine("Process completed...");
        }
    }
}