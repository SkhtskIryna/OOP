using program;
namespace lab2
{
    // Базовий клас для гри
    public class BaseGame : Game
    {
        public BaseGame(int Number, GameAccount player, GameAccount opponent, string Title, int Duration) : base(Number, player, opponent){
            Player = player;
            Opponent = opponent;
            this.Title = Title;
            this.Duration = Duration;
            Type = GameType.Base;
        }
    }
}