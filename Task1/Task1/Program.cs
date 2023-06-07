using System;

public class Program
{
    const int MinLength = 8;
    const int MaxLength = 30;


    public static void Main()
    {
        try
        {
            DbManager dbManager = new DbManager();

            GameManager gameManager = new GameManager();

            ICommand reader = new CommandReader();

            string? name = reader.PromptInput("Player1 enter your name (press Enter to finish):");

            Player pl1 = dbManager.FindOrCreatePlayer(name);

            name = reader.PromptInput("Player2 enter your name (press Enter to finish):");

            Player pl2 = dbManager.FindOrCreatePlayer(name);

            List<string> wordsList = new List<string>();

            string? initialWord = GetInitialWord();

            Console.WriteLine($"Initial word: {initialWord}.The game has started.");

            string? word;
           
            while (true)
            {
                
                word = gameManager.ReadCommand(pl1, pl2, wordsList, pl1.Name);

                if (!IsValidPlayerWord(initialWord, word))
                {

                    pl1.FailsNumber++;
                    pl2.WinsNumber++;
                    PrintMessage(word, pl2);
                    break;
                }
                else
                {
                                       
                    word = gameManager.ReadCommand(pl1, pl2, wordsList, pl2.Name);

                    if (IsValidPlayerWord(initialWord, word))
                    {
                        continue;
                    }
                    else
                    {
                        pl2.FailsNumber++;
                        pl1.WinsNumber++;
                        PrintMessage(word, pl1);
                        break;
                    }
                }
            }

            dbManager.SavePlayer(pl1, pl2);
        }     

        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static bool IsValidPlayerWord(string? input, string? word) => !string.IsNullOrEmpty(word) && word.All(ch => input.Contains(ch) &&
                                                                         word.GroupBy(c => c)
                                                                             .All(g => g.Count() <= input.Count(c => c == g.Key)));

    public static bool IsInvalidInitialWord(string? word) => word is null || word?.Length < MinLength || word?.Length >= MaxLength || !word!.All(Char.IsLetter);


    public static string GetInitialWord()
    {
        string? initialWord;

        do
        {
            Console.WriteLine($"Enter a word longer than {MinLength} and less than {MaxLength} characters to start a game:");
            initialWord = Console.ReadLine();
        }
        while (IsInvalidInitialWord(initialWord));
        return initialWord;
    }

    
    public static void PrintMessage(string word, Player player)
    {
        if (string.IsNullOrEmpty(word))
        {
            Console.WriteLine($"You didn't enter a word. You lost: {player.Name} is winner");
        }
        else
        {
            Console.WriteLine($"The entered word: {word} is invalid. You lost: {player.Name} is winner");
        }

    }

   



}
