using System;

class Program
{
    static void Main()
    {
        try
        {
            throw new Exception("This is a custom exception message.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }

        try
        {
            bool condition = false;

            if (!condition)
            {
                throw new InvalidOperationException("Invalid operation occurred.");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Caught InvalidOperationException: " + ex.Message);
        }
    }
}
