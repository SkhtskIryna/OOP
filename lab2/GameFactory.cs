namespace lab2
{
    public class GameFactory
    {
        public static Game gameFactory(int Number, GameType gameType, VipPlayer player, GameAccount opponent, int Rating, string Title, int Duration)
        {
            Game game = null;

            if (gameType == GameType.Base)
            {
                game = new BaseGame(Number, player, opponent, Title, Duration);
            }
            else if (gameType == GameType.Training)
            {
                game = new TrainingGame(Number, player, opponent, Title, Duration);
            }
            else if (gameType == GameType.Solo)
            {
                game = new SoloGame(Number, player, opponent, Rating, Title, Duration);
            }

            return game;
        }
    }
}
