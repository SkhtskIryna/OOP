namespace lab2
{
    public class SoloGame : Game
    {
        public SoloGame(int Number, VipPlayer player, BasePlayer opponent, int Rating) : base()
        {
            Player = player;
            Opponent = opponent;
            this.Rating = Rating;
            Type = GameType.Solo;
        }
    }
}
