namespace lab2
{
    public class PremiumPlayer : GameAccount
    {
        public PremiumPlayer(string userName, int CurrentRating) : base(userName, CurrentRating)
        {
        }

        public override void LoseGame(GameAccount opponent, Game game)
        {
            CurrentRating -= game.Rating / 3;
        }

        public override void WinGame(GameAccount opponent, Game game)
        {
            CurrentRating += game.Rating * 3;
        }
    }
}
