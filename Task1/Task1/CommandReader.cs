class CommandReader : ICommand
{
    public void ShowWords(List<string> words)
    {
        Console.WriteLine("Total words:");
        Console.WriteLine(string.Join(", ", words));
    }

    public void DisplayTotalScore(List<Player> players)
    {
        Console.WriteLine("Total score:");
        foreach (Player p in players)
        {
            DisplayCurrentScore(p);
        }
    }

    public void DisplayCurrentScore(Player player)
    {
        Console.WriteLine($"{player.Name} - Won:{player.WinsNumber},Lost:{player.FailsNumber}");
    }

    public string PromptInput(string input)
    {
        Console.WriteLine(input);

        return Console.ReadLine();
    }
}
