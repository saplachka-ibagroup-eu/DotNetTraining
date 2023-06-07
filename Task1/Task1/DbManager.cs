
using Microsoft.EntityFrameworkCore;

public class DbManager
{
    private readonly ApplicationContext _context;

    public DbManager()
    {
        _context = new();
    }

    public void SavePlayer(params Player[] players)
    {
        _context.Players.UpdateRange(players);
        _context.SaveChanges();             
    }

    public Player FindOrCreatePlayer(string name)
    {
        Player? player = _context.Players.FirstOrDefault(p => p.Name == name);

        if (player == null)
        {
            player = new Player();
            player.Name = name;
            _context.Players.Add(player);
            _context.SaveChanges();

        }
        return player;
    }    

    public List<Player> GetPlayers()
    {
        return _context.Players.ToList();      
    }
         
}

