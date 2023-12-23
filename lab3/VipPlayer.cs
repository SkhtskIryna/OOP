namespace lab2
{
    public class VipPlayer : BasePlayer
    {
        public VipPlayer() : base()
        {
        }

        public override void LoseGame(BasePlayer opponent, Game game)
        {
            CurrentRating -= game.Rating / 2;
        }

        public override void WinGame(BasePlayer opponent, Game game)
        {
            CurrentRating += game.Rating * 2;
        }
    }
}
