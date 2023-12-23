namespace lab2
{
    public class GameFactory
    {
        public static Game gameFactory(int Number, GameType gameType, BasePlayer player, BasePlayer opponent, int Rating)
        {
            Game game = null;

            if (gameType == GameType.Base)
            {
                game = new BaseGame(Number, player, opponent);
            }
            else if (gameType == GameType.Training)
            {
                game = new TrainingGame(Number, player, opponent);
            }
            else if (gameType == GameType.Solo)
            {
                game = new SoloGame(Number, player, opponent, Rating);
            }

            return game;
        }
    }
}
