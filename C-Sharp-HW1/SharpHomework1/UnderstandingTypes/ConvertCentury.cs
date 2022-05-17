namespace UnderstandingTypes;

public static class ConvertCentury
{
    public static void Convert(uint century)
    {
        uint year = century * 100;
        
        uint day = year * 365;
        day += (year- year%4) / 4;
        
        //uint day = century * 36524;
        ulong hour = day * (ulong)24;
        ulong minute = hour * 60;
        ulong second = minute * 60;
        ulong millisecond = second * 1000;
        ulong microsecond = millisecond * 1000;
        ulong nanosecond = microsecond * 1000;
        string result = String.Format("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes" +
                                      "= {5} seconds = {6} milliseconds = {7} microseconds = {8} nanoseconds",
            century,year, day, hour,minute, second, millisecond, microsecond, nanosecond);
        Console.WriteLine(result);
    }
}