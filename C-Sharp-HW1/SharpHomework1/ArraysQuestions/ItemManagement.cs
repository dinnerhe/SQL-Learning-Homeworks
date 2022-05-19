namespace ArraysQuestions;

public class ItemManagement
{
    public static List<string> Manage()
    {
        List<string> grocery = new List<string>();
        while (true)
        {
            Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
            string input = Console.ReadLine() ?? string.Empty;
            string op = input.Substring(0, 2);
            if (op.Equals("- ")) grocery.Remove(input.Substring(2, input.Length - 2));
            else if (op.Equals("+ ")) grocery.Add(input.Substring(2, input.Length - 2));
            else if (op.Equals("--")) grocery.Clear();
            else break;
        }

        return grocery;
    }
}