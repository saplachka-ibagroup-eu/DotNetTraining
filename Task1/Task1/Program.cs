using System;


public class Program
{
    const int MinLength = 8;
    const int MaxLength = 30;

    public static void Main()
    {
        
        string? initialWord = GetInitialWord();

        Console.WriteLine($"Initial word: {initialWord}.The game has started.");


        while (true)
        {
            Console.WriteLine("Player1 enter a word (press Enter to finish):");
            
            string? player1 = Console.ReadLine();

            if (!IsValidPlayerWord(initialWord, player1))
            {   
                PrintMessage(player1, "Player2");
                break;
            }
            else
            {
                Console.WriteLine("Player2 enter a word (press Enter to finish):");
                string? player2 = Console.ReadLine();
                if (IsValidPlayerWord(initialWord, player2))
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

    public static bool IsValidPlayerWord(string? input, string? word) => !string.IsNullOrEmpty(word) && word.All(ch => input.Contains(ch) &&
                                                                          word.GroupBy(c => c)
                                                                              .All(g => g.Count() <= input.Count(c => c == g.Key)));

    public static bool IsInvalidInitialWord(string? word) => word is null || word?.Length < MinLength || word?.Length >= MaxLength || !word!.All(Char.IsLetter);

    

    public static string GetInitialWord() {
        string? initialWord;


        do
        {
            Console.WriteLine($"Enter a word longer than {MinLength} and less than {MaxLength} characters to start a game:");
            initialWord = Console.ReadLine();

        }
        while (IsInvalidInitialWord(initialWord));
        return initialWord;
    }

    public static void PrintMessage(string word,string player)
    {
        if (string.IsNullOrEmpty(word))
        {
            Console.WriteLine($"You didn't enter a word. You lost: {player} is winner");
        }

        else 
        { 
            Console.WriteLine($"The entered word: {word} is invalid. You lost: {player} is winner"); 
        }
    }

}
