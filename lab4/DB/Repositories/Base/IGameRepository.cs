using lab2;

namespace lab3.DB.Repositories.Base
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAllGames();
        Game GetById(int id);
        void Create(Game game);
        void Update(Game game, int id);
        void Delete(int id);
    }
}