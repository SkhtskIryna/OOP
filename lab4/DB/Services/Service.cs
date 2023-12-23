using lab3.DB.Repositories.Base;
using lab3.DB.Services.Base;
using lab3.DB.Repositories;
using lab2;

namespace lab3.DB.Services
{
    public class Service : IService
    {
        public IPlayerRepository newPlayer = new PlayerRepository();
        public IGameRepository newGame = new GameRepository();

        public int gameid = 1;

        public BasePlayer CreateAccount(int ind, string UserName, int rating, int ID, Service service)
        {
            BasePlayer player = new BasePlayer(UserName, rating, ID);

            if (ind == 1)
            {
                player = new VipPlayer(UserName, rating, ID);
                newPlayer.Create(player);
            }
            if (ind == 2)
            {
                player = new BasePlayer(UserName, rating, ID);
                newPlayer.Create(player);
            }
            if (player == null)
            {
                throw new NotImplementedException();
            }
            Console.WriteLine(player.UserName);

            return player;
        }

        public void CreateGame(BasePlayer player1, BasePlayer player2, Game game, Service service)
        {
            player1.gameid.Add(game.GameId);
            player2.gameid.Add(game.GameId);

            newGame.Create(game);
        }

        public BasePlayer ReadAccountById(int id, Service service)
        {
            BasePlayer player = newPlayer.GetById(id);

            if (player == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                return player;
            }
        }

        public void ReadAccounts()
        {
            Console.WriteLine($"\nAll accounts from database:");
            foreach (BasePlayer player in newPlayer.GetAllPlayers())
            {
                Console.WriteLine(player.UserName);
            }
            Console.WriteLine();
        }

        public void ReadGames()
        {
            Console.WriteLine();
            Console.WriteLine($"\nFinished Games:");
            foreach (Game game in newGame.GetAllGames())
            {
                Console.WriteLine($"Game ID: {game.GameId}\nType game: {game.Type}\nIndentifier game: {game.Number}\n");
            }
            Console.WriteLine();
        }

        public void ReadPlayedGamesByPlayer(int id, Service service)
        {
            BasePlayer player = newPlayer.GetById(id);
            Game game = newGame.GetById(id);

            Console.WriteLine($"\nFinished Games by player {player.UserName}:\nPlayer ID: {player.ID}\nGame ID: {game.GameId}\nResult: {game.IsWin}\nType game: {game.Type}\nRating: {player.CurrentRating}\n");
        }
    }
}
