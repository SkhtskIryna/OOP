using lab3.DB.Services.Base;
using lab3.DB.Services;
using lab2;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            IService service = new Service();
            BasePlayer player = new BasePlayer();

            var player1 = service.CreateAccount(1, "Veronika", 10, 5);
            var player2 = service.CreateAccount(2, "Nika", 10, 6);

            player.Run((VipPlayer)player1, player2);
        }
    }
}