namespace ArraysQuestions;

public class CopyArray
{
    public static void Copy()
    {
        int[] Array1 = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] CopyOfArray = new int[Array1.Length];
        for (int i = 0; i < Array1.Length; i++)
        {
            CopyOfArray[i] = Array1[i];
        }
        Console.WriteLine($"Original Array: {String.Join(',', Array1)}\nCopied Array: {string.Join(',', CopyOfArray)}");
    }
}