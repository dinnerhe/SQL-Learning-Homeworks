using System.Text;

namespace Loops_Operators_Questions;

public static class Print_a_Pyramid
{
    public static void printPyramid()
    {
        int length = 9; // the length of base
        int half = (length - 1) / 2;
        for (int i = 0; i <= half; i++)
        {
            StringBuilder sb = new StringBuilder();
            int numOfBlankHalf = half - i;
            int numOfStarHalf = i;
            for (int j = 0; j < numOfBlankHalf; j++)
            {
                sb.Append(' ');
            }
            for (int j = 0; j < numOfStarHalf*2; j++)
            {
                sb.Append('*');
            }
            sb.Append('*');
            for (int j = 0; j < numOfBlankHalf; j++)
            {
                sb.Append(' ');
            }
            Console.WriteLine(sb.ToString());
        }
    }
    
}