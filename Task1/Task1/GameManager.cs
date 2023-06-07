
public class GameManager
{

    private readonly DbManager dbManager;

    public GameManager()
    {
        dbManager = new();
    }

    ICommand reader = new CommandReader();
        
    public string ReadCommand(Player p1, Player p2, List<string> wordsList, string currentPlayer)
    {
        string input = reader.PromptInput($"{currentPlayer} enter a word (press Enter to finish):");

        while (input.StartsWith('/'))
        {
            switch (input)
            {
                case "/show-words":
                    reader.ShowWords(wordsList);
                    break;
                case "/score":
                    reader.DisplayCurrentScore(p1);
                    reader.DisplayCurrentScore(p2);
                    break;
                case "/total-score":
                    reader.DisplayTotalScore(dbManager.GetPlayers());
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
            input = reader.PromptInput($"{currentPlayer} enter a word (press Enter to finish):");
        }
        if (!input.StartsWith('/'))
        {
            wordsList.Add(input);
        }
        return input;
    }

    
}

