using lab2;
using lab3.DB.Services;
using lab3.ShowInfo.Base;

namespace lab3.ShowInfo
{
    internal class CreateAccount : IShowInfo
    {

        public void Show()
        {
            Console.WriteLine("1. Create new account");
        }


        public void Action(Service service)
        {
            int ind, id;
            string name;
            int pts = 10;
            Console.WriteLine("\nEnter ind: ");
            ind = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter id: ");
            id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your nickname: ");
            name = Console.ReadLine();

            BasePlayer account = service.CreateAccount(ind, name, pts, id, service);
        }
        
    }
}
