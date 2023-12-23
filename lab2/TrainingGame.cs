namespace lab2
{
    public class TrainingGame : Game
    {
        public TrainingGame(int Number, GameAccount player, GameAccount opponent, string Title, int Duration) : base(Number, player, opponent)
        {
            Player = player;
            Opponent = opponent;
            this.Title = Title;
            this.Duration = Duration;
            Type = GameType.Training;
        }
    }
}
