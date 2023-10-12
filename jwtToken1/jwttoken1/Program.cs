// See https://aka.ms/new-console-template for more information


namespace jwttoken1
{
    class Program
    {
        static void Main(string[] args)
        {
            string secretKey1 = "9732b563c9f032238bc0a783a7d1adda4abd020c18db32da4600bd3764bef249";
            Console.WriteLine("===");
            var jwtService = new JwtService(secretKey1, "davs", "all", 60);
            string token = jwtService.GenerateToken("Jamecho", 123);
            Console.WriteLine(token);
            Console.WriteLine();

            Console.WriteLine("===256Key");
            var hmacSha256Key = KeyGenerator.GenerateHmacSha256Key();
            Console.WriteLine(hmacSha256Key);
            Console.WriteLine();

            Console.WriteLine("===512Key");
            var hmacSha512Key = KeyGenerator.GenerateHmacSha512Key();
            Console.WriteLine(hmacSha512Key);
            Console.WriteLine();

            // Console.WriteLine("===");

        }
    }


}