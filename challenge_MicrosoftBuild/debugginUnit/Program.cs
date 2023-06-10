using System.Diagnostics;

// See https://aka.ms/new-console-template for more information
int result = Fibonacci(5);
Console.WriteLine(result);
Console.WriteLine("This message is readable by the end user.");
Trace.WriteLine("This is a trace message when tracing the app.");
Debug.WriteLine("This is a debug message just for developers.");
Debug.WriteLine($"Entering {nameof(Fibonacci)} method");


static int Fibonacci(int n)
{
    int n1 = 0;
    int n2 = 1;
    int sum;

    for (int i = 2; i <= n; i++)
    {
        sum = n1 + n2;
        n1 = n2;
        n2 = sum;
    }

    Debug.WriteLine($"We are looking for the {n}th number");

    for (int i = 2; i <= n; i++)
{                  
    sum = n1 + n2;
    n1 = n2;
    n2 = sum;
    Debug.WriteLineIf(sum == 1, $"sum is 1, n1 is {n1}, n2 is {n2}");    
}

    // If n2 is 5 continue, else break.
    Debug.Assert(n2 == 5, "The return value is not 5 and it should be.");
    return n == 0 ? n1 : n2;
}

int IntegerDivide(int dividend, int divisor)
{
    // these are ways to debug
    // int divisor = 1;
    int count = 2;
    Debug.Assert(divisor != 0, $"{nameof(divisor)} is 0 and will cause an exception.");
    Debug.WriteLineIf(count == 0, "The count is 0 and this may cause an exception.");

    return dividend / divisor;
}
