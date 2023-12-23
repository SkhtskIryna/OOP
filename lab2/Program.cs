using lab2;

namespace program
{
    class Program
    {
        public static void Main(string[] args)
        {
            VipPlayer player1 = new VipPlayer("Ira", 1);
            GameAccount player2 = new GameAccount("Diana", 1);
            GameAccount player3 = new GameAccount("Vika", 1);
            PremiumPlayer player4 = new PremiumPlayer("Dima", 2);

            player1.Run(player1, player2, player3, player4); 
        }
    }

}