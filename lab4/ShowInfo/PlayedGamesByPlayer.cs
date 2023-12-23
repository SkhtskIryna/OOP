using lab2;
using lab3.DB.Services;
using lab3.ShowInfo.Base;

namespace lab3.ShowInfo
{
    public class PlayedGamesByPlayer : IShowInfo
    {

        public void Show()
        {
            Console.WriteLine("3. Show finished games by account");
        }

        public void Action(Service service)
        {
            Console.WriteLine("\nEnter player ID: ");

            int ID = Convert.ToInt32(Console.ReadLine());

            service.ReadPlayedGamesByPlayer(ID, service);
        }
    }
}
