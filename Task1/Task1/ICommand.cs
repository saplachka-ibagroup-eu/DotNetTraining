public interface ICommand
{
  void ShowWords(List<string> words);
  void DisplayTotalScore(List<Player> players);
  void DisplayCurrentScore(Player player);
  string PromptInput(string player);



}
