namespace Loops_Operators_Questions;

public class Greetings
{
    public static void Greets(DateTime time)
    {
        int hour = time.Hour;
        if(hour is >=6 and <12) Console.WriteLine("Good Morning");
        if(hour is >=12 and <19) Console.WriteLine("Good Afternoon");
        if(hour is >= 19 and < 21) Console.WriteLine("Good Evening");
        if(hour is >=21 or <6) Console.WriteLine("Good Night");
    }
}