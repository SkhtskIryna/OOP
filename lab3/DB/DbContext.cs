using lab2;

namespace lab3.DB
{
    public class DbContext
    {
        public List<BasePlayer> Players { get; set; }
        public List<Game> Games { get; set; }

        public DbContext()
        {
            Players = new List<BasePlayer> {
                new VipPlayer { ID = 1, UserName = "Ira", rating = 3 },
                new BasePlayer { ID = 2, UserName = "Diana",  rating = 2 },
                new BasePlayer { ID = 3, UserName = "Dima", rating = 1 },
                new BasePlayer { ID = 4, UserName = "Vika",  rating = 1 },
            };
            Games = new List<Game> {
                new Game { GameId = 1, IsWin = "Win", Type = GameType.Solo},
                new Game { GameId = 2, IsWin = "Win", Type = GameType.Training},
                new Game { GameId = 3, IsWin = "Lost", Type = GameType.Base},
            };
        }
    }
}
