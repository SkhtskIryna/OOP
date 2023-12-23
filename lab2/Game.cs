namespace lab2
{
    public abstract class Game
    {
        private static int accoundNumberInd = 12345;//задаємо унікальний індентифікатор
        public string Number { get; }

        public GameAccount Player { get; set; }
        public GameAccount Opponent { get; set; }
        public int Rating { get; set; }
        public GameType Type { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }

        public Game(int Number, GameAccount player, GameAccount opponent)
        {
            this.Number = accoundNumberInd.ToString();//призначаємо рядок, який представляє індентифікатор
            Player = player;
            Opponent = opponent;
            accoundNumberInd++;
        }

        public void Start()
        {
            Console.WriteLine($"{Title} game is starting. Duration: {Duration} minutes.");
        }

        public void Play(GameAccount player, GameAccount opponent, string IsWin) {
            player.PlayGame(opponent, IsWin, this);
        }

        public void End()
        {
            Console.WriteLine($"{Title} game is ending.");
        }
    }
}
