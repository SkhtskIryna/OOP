namespace lab2
{
    public class GameStats
    {
        public string IsWin { get; set; }
        public string OpponentName;
        public string UserName { get; }
        public decimal Rating { get; }
        public string gameType { get; set; }

        public GameStats(int GameId, string opponentName, string userName, decimal rating)
        {
            this.IsWin = IsWin;
            OpponentName = opponentName;
            UserName = userName;
            Rating = rating;
            this.gameType = gameType;
            GameId = GameId;
            GameId++;
        }
    }
}
