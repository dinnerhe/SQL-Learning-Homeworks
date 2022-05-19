namespace Loops_Operators_Questions;

public class CalculateAge
{
    public static int calc()
    {
        string birth_date = "19980821";
        int year = Convert.ToInt32(birth_date.Substring(0, 4));
        int month = Convert.ToInt32(birth_date.Substring(4, 2));
        int day = Convert.ToInt32(birth_date.Substring(6, 2));
        DateTime birth = new DateTime(year, month, day);
        DateTime today = DateTime.Today;
        TimeSpan diff = today - birth;
        int age_in_days = diff.Days;
        int age = (age_in_days - age_in_days % 365) / 365;
        int daysToNextAnniversary = 10000 - (age_in_days % 100000);
        Console.WriteLine($"The age is {age}");
        Console.WriteLine($"The next 10,00 day anniversary happens in {daysToNextAnniversary} days");
        return age;
    }
}