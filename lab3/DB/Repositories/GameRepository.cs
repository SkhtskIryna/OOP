using lab2;
using lab3.DB.Repositories.Base;

namespace lab3.DB.Repositories
{
    public class GameRepository : IGameRepository
    {
        private DbContext context;
        public GameRepository()
        {
            this.context = new DbContext();
        }

        public IEnumerable<Game> GetAllGames()
        {
            return context.Games;
        }

        public void Create(Game game)
        {
            context.Games.Add(game);
        }

        public void Delete(int id)
        {
            Game game = context.Games.FirstOrDefault(game => game.GameId == id);
            if (game != null)
            {
                context.Games.Remove(game);
            }
        }

        public Game GetById(int id)
        {
            return context.Games.FirstOrDefault(game => game.GameId == id);
        }

        public void Update(Game game, int id)
        {
            game.GameId = id;
        }
    }
}
