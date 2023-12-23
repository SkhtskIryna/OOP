using lab3.DB.Services;
using lab3.ShowInfo.Base;

namespace lab3.ShowInfo
{
    public class ReadAllGames : IShowInfo
    {
        public void Show()
        {
            Console.WriteLine("4. Show all games");
        }

        public void Action(Service service)
        {
            service.ReadGames();
        }
    }
}
