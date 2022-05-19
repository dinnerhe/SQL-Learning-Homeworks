// See https://aka.ms/new-console-template for more information

using System.Collections;

static int[] GenerateNumbers(int len)
{
    int[] result = new int[len];
    for (int i = 0; i < len; i++) result[i] = i + 1;
    return result;
}

static void Reverse(int[] arr)
{
    int left = 0;
    int right = arr.Length - 1;
    while (left <= right)
    {
        int temp = arr[right];
        arr[right] = arr[left];
        arr[left] = temp;
        left++;
        right--;
    }
}

static void PrintNumbers(int[] numbers)
{
    foreach(int number in numbers) Console.WriteLine(number);
}

int[] numbers = GenerateNumbers(10);
Reverse(numbers);
PrintNumbers(numbers);
