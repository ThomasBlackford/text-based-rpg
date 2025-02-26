namespace Text_Based_RPG;

public static class inputHelper
{
    public static string ReadYesNo(string prompt)
    {
        string input = string.Empty;
        while (true)
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine().Trim().ToUpper();
            if (input == "Y" || input == "N")
                break;
            else
            {
                Console.WriteLine("Invalid input. Please enter Y/N.");
            }
        }
        return input;
    }

    public static int ReadInt(string prompt)
    {
        int result;
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out result))
                break;
            else 
                Console.WriteLine("Invalid Input. Please enter a valid integer.");
        }

        return result;
        
    }
}