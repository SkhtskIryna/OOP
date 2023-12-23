using lab2;

namespace lab3.DB.Services.Base
{
    public interface IService
    {
        public BasePlayer CreateAccount(int ind, string UserName, int rating, int ID);
        public void ReadAccounts();
        public BasePlayer ReadAccountById(int id);
        public void ReadGames();
        public void ReadPlayedGamesByPlayer(int id);
        public void CreateGame(VipPlayer player1, BasePlayer player2, Game game);
    }
}
