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

        public BasePlayer CreateAccount(int ind, string UserName, int rating, int ID)
        {
            BasePlayer player = new BasePlayer();

            if (ind == 1)
            {
                player = new VipPlayer();
                newPlayer.Create(player);
            }
            if (ind == 2)
            {
                player = new BasePlayer();
                newPlayer.Create(player);
            }
            if (player == null)
            {
                throw new NotImplementedException();
            }

            return player;
        }

        public void CreateGame(VipPlayer player1, BasePlayer player2, Game game)
        {
            player1.gameid.Add(game.GameId);
            player2.gameid.Add(game.GameId);

            newGame.Create(game);
        }

        public BasePlayer ReadAccountById(int id)
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
            Console.WriteLine($"All active accounts:");
            foreach (BasePlayer player in newPlayer.GetAllPlayers())
            {
                Console.WriteLine(player.UserName);
            }
            Console.WriteLine();
        }

        public void ReadGames()
        {
            Console.WriteLine();
            Console.WriteLine($"Finished Games:");
            foreach (Game game in newGame.GetAllGames())
            {
                Console.WriteLine($"Game ID: {game.GameId}\nType game: {game.Type}\n");
            }
            Console.WriteLine();
        }

        public void ReadPlayedGamesByPlayer(int id)
        {
            BasePlayer player = newPlayer.GetById(id);
            Game game = newGame.GetById(id);

            Console.WriteLine($"\nFinished Games by player {player.UserName}:\nPlayer ID: {player.ID}\nGame ID: {game.GameId}\nResult: {game.IsWin}\nType game: {game.Type}\nRating: {player.CurrentRating}\n");
        }
    }
}
