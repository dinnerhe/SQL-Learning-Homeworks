// See https://aka.ms/new-console-template for more information

static int Fibonacci(int index)
{
    int first = 1, second = 1;
    int cur = 1;
    for (int i = 3; i <= index; i++)
    {
        cur = first + second;
        first = second;
        second = cur;
    }
    return cur;
}

for (int i = 1; i <= 10; i++)
{
    Console.WriteLine(Fibonacci(i));
}
