namespace lab2
{
    // Базовий клас для гри
    public class BaseGame : Game
    {
        public BaseGame(int Number, BasePlayer player, BasePlayer opponent) : base(){
            Player = player;
            Opponent = opponent;
            Type = GameType.Base;
        }
    }
}