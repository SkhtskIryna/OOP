using lab2;
using lab3.DB.Services;
using lab3.ShowInfo.Base;

namespace lab3.ShowInfo
{
    public class Play : IShowInfo
    {
        public void Show()
        {
            Console.WriteLine("5. Play the game");
        }

        public void Action(Service service)
        {
            BasePlayer p1 = new BasePlayer();
            BasePlayer p2 = new BasePlayer();

            service.CreateGame(p1, p2, GameFactory.gameFactory(0, GameType.Base, p1, p2, 1), service: service);
        }
    }
}
