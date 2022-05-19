using System.Text;

namespace Loops_Operators_Questions;

public class Count24
{
    public static void Count()
    {
        
        for (int num = 1; num <= 4; num++)
        {
            List<int> result = new List<int>();
            for (int i = 0; i <= 24; i+=num)
            {
                result.Add(i);
            }
            Console.WriteLine(String.Join(',', result));
        }

        
    }
}