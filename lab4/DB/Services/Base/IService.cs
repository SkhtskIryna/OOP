using lab2;

namespace lab3.DB.Services.Base
{
    public interface IService
    {
        public BasePlayer CreateAccount(int ind, string UserName, int rating, int ID, Service service);
        public void ReadAccounts();
        public BasePlayer ReadAccountById(int id, Service service);
        public void ReadGames();
        public void ReadPlayedGamesByPlayer(int id, Service service);
        public void CreateGame(BasePlayer player1, BasePlayer player2, Game game, Service service);
    }
}
