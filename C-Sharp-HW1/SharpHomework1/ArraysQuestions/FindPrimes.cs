namespace ArraysQuestions;

public class FindPrimes
{
    public static int[] Find(int startNum, int endNum)
    {
        List<int> resList = new List<int>();
        if (startNum > endNum) return resList.ToArray();
        for (int i = startNum; i <= endNum; i++)
        {
            if(is_prime(i)) resList.Add(i);
        }

        return resList.ToArray();

    }

    public static bool is_prime(int number)
    {
        double range = Math.Pow(number, 0.5);
        if (number <= 3) return true;
        if (number % 2 == 0) return false;
        for (int i = 3; i <= range; i += 2)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
}