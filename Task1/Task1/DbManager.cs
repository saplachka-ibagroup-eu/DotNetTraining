
public class DbManager
    {
    public static void SavePlayer(Player player1, Player player2)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Players.UpdateRange(player1, player2);
            db.SaveChanges();            
        }
    }

    public static Player FindOrCreatePlayer()
    {
        using (ApplicationContext db = new ApplicationContext())
        {

            string? name = Console.ReadLine();

            Player? player = db.Players.FirstOrDefault(p => p.Name == name);

            if (player == null)
            {
                player = new Player();
                player.Name = name;
                db.Players.Add(player);
                db.SaveChanges();

            }
            return player;

        }
    }


    public static void DisplayTotalScore()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var players = db.Players.ToList();
            Console.WriteLine("Total score:");
            foreach (Player p in players)
            {
                Console.WriteLine($"{p.Name} - Won:{p.WinsNumber},Lost:{p.FailsNumber}");
            }
        }
    }

    public static void DisplayCurrentScore(Player player)
    {
        using (ApplicationContext db = new ApplicationContext())
        {

            Player? p = db.Players.FirstOrDefault(p => p.Name == player.Name);

            if (p != null)
            {
                Console.WriteLine($"{p.Name} - Won:{p.WinsNumber},Lost:{p.FailsNumber}");
            }
            else
            {
                Console.WriteLine("Player not found");
            }

        }
    }

    public static void ShowWords(List<string> words)
    {
        Console.WriteLine("Total words:");
        Console.WriteLine(string.Join(", ", words));
    }

    public static string ReadCommands(Player p1, Player p2, List<string> wordsList, string currentPlayer)
    {
        string? word = Console.ReadLine();


        while (word.StartsWith('/'))
        {
            switch (word)
            {
                case "/show-words":
                    ShowWords(wordsList);
                    break;
                case "/score":
                    Console.WriteLine("Score for current players:");
                    DisplayCurrentScore(p1);
                    DisplayCurrentScore(p2);
                    break;
                case "/total-score":
                    DisplayTotalScore();
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
            Console.WriteLine($"{currentPlayer} enter a word (press Enter to finish):");
            word = Console.ReadLine();
        }
        if (!word.StartsWith('/'))
        {
            wordsList.Add(word);
        }
        return word;
    }

}

