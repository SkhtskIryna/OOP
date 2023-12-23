using lab3.DB.Services;
using lab3.ShowInfo.Base;

namespace lab3.ShowInfo
{
    public class GetAllAccounts : IShowInfo
    {
        public void Action(Service service)
        {
            service.ReadAccounts();
        }

        public void Show()
        {
            Console.WriteLine("2. Get all accounts with database");
        }
    }
}
