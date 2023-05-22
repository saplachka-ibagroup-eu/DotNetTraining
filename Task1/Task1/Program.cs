using System;


public class Program
{
    public static void Main()
    {
        string? initialWord = GetInitialWord();

        Console.WriteLine($"Initial word: {initialWord}.The game has started.");


        while (true)
        {
            Console.WriteLine("Player1 enter a word (press Enter to finish):");
            
            string? player1 = Console.ReadLine();

            if (!IsValidWord(initialWord, player1))
            {   PrintMessage(player1, "Player2");
                break;
            }
            else
            {
                Console.WriteLine("Player2 enter a word (press Enter to finish):");
                string? player2 = Console.ReadLine();
                if (IsValidWord(initialWord, player2))
                {
                    continue;
                }
                else
                {
                    PrintMessage(player2, "Player1");
                    break;
                }
            }
        }
    }

    public static Boolean IsValidWord(string input, string word) => !string.IsNullOrEmpty(word) && word.All(ch => input.Contains(ch) &&
                                                                            word.GroupBy(c => c)
                                                                                .All(g => g.Count() <= input.Count(c => c == g.Key)));
    public static string GetInitialWord() {
        string? initialWord;
        const int MIN_LENGTH = 8;
        const int MAX_LENGTH = 30;

        do
        {
            Console.WriteLine($"Enter a word longer than {MIN_LENGTH} and less than {MAX_LENGTH} characters to start a game:");
            initialWord = Console.ReadLine();

        }
        while (initialWord is null || initialWord?.Length < MIN_LENGTH || initialWord?.Length >= MAX_LENGTH || !initialWord!.All(Char.IsLetter));
        return initialWord;
    }

    public static void PrintMessage(string word,string player)
    {
        if (string.IsNullOrEmpty(word))
        {
            Console.WriteLine($"You didn't enter a word. You lost: {player} is winner");
        }

        else { Console.WriteLine($"The entered word: {word} is invalid. You lost: {player} is winner"); }
    }

}
