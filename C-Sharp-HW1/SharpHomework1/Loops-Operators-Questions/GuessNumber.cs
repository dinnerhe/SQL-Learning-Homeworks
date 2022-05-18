namespace Loops_Operators_Questions;

public static class GuessNumber
{
    public static void Guess()
    {
        Random rnd = new Random();
        int number  = rnd.Next(1, 4);
        Console.Write("Enter the number you guess: ");
        int guessedNumber = int.Parse(Console.ReadLine());
        if(guessedNumber >3 || guessedNumber <1) Console.WriteLine("Invalid Number!");
        else if(guessedNumber > number) Console.WriteLine("Your number is higher");
        else if(guessedNumber < number) Console.WriteLine("Your number is lower");
        else Console.WriteLine("The number you guessed is correct!");
    }
}