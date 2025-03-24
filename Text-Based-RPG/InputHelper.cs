using System.Net.Mime;

namespace Text_Based_RPG;
using Text_Based_RPG;
using System;
using System.Collections.Generic;

/*
 * Made by: Thomas Blackford
 */

public static class InputHelper
{
    public static string ReadYesNo(string prompt)
    {
        string input;
        while (true)
        {
            Console.WriteLine(prompt + " (Y/N)");
            input = Console.ReadLine().Trim().ToUpper();
            if (input == "Y" || input == "N")
                return input;
            else
                Console.WriteLine("Invalid input. Please enter Y or N.");
        }
    }

    public static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result))
                return result;
            else
                Console.WriteLine("Invalid Input. Please enter a valid integer.");
        }
    }

    public static string ReadString(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine().Trim();
    }

    public static string ReadChoice(string prompt, List<string> options)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {options[i]}");
            }

            string input = Console.ReadLine().Trim();
            if (int.TryParse(input, out int choice) && choice > 0 && choice <= options.Count)
                return options[choice - 1];
            
            Console.WriteLine("Invalid choice. Please enter a number corresponding to an option.");
        }
    }
}