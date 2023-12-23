namespace lab2
{
    public class GameResult//створюємо класс GameResult для подальшої роботи з властивостями 
    {
        public GameType gameType { get; set; }//оголошуємо властивості, зчитуємо та записуємо
        public string opponentName { get; set; }
        public int Rating { get; set; }
        public int CurrentRating { get; set; }
        public string IsWin { get; set; }

        public GameResult(GameType type, string opponentName, int rating, int currentRating, string IsWin)
        {
            this.gameType = type;
            this.opponentName = opponentName;
            Rating = rating;
            this.CurrentRating = currentRating;
            this.IsWin = IsWin;
        }
    }
}