namespace lab2
{
    public class Game
    {
        private static int accoundNumberInd = 12345;//задаємо унікальний індентифікатор
        public int GameId { get; set; }
        public string Number { get; }
        public BasePlayer Player { get; set; }
        public BasePlayer Opponent { get; set; }
        public int Rating { get; set; }
        public GameType Type { get; set; }
        public string IsWin { get; set; }
        public List<Game> Games { get; set; }

        public Game()
        {
            this.Number = accoundNumberInd.ToString();//призначаємо рядок, який представляє індентифікатор
            this.GameId = GameId;
            this.Player = Player;
            this.Opponent = Opponent;
            this.Type = Type;
            this.IsWin = IsWin;
            accoundNumberInd++;

            Games = new List<Game>();
        }

        public void Play(BasePlayer player, BasePlayer opponent, string IsWin) {
            player.PlayGame(opponent, IsWin, this);
        }
    }
}
