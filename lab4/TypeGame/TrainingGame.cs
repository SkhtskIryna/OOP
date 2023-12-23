namespace lab2
{
    public class TrainingGame : Game
    {
        public TrainingGame(int Number, BasePlayer player, BasePlayer opponent) : base()
        {
            Player = player;
            Opponent = opponent;
            Type = GameType.Training;
        }
    }
}
