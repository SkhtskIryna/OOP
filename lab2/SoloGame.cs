namespace lab2
{
    public class SoloGame : Game
    {
        public SoloGame(int Number, VipPlayer player, GameAccount opponent, int Rating, string Title, int Duration) : base(Number, player, opponent)
        {
            Player = player;
            Opponent = opponent;
            this.Rating = Rating;
            this.Title = Title;
            this.Duration = Duration;
            Type = GameType.Solo;
        }

        public void PlaySolo(int numberRound)
        {
            Console.WriteLine($"Playing solo game {Title} with difficulty level {numberRound}.");
        }
    }
}
