namespace lab2
{
    public class VipPlayer : BasePlayer
    {
        public VipPlayer(string UserName = "Veronika", int rating = 10, int ID = 5)
        {
            this.ID = ID;
            this.UserName = UserName;
            this.rating = rating;
            this.CurrentRating = rating;

            gameid = new List<int>();
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
