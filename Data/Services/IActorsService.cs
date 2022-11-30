using eTickets.Data.Services;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorsService : IEntityBaseRepository<Actor>
    {
        //sync method
        //IEnumerable<Actor> GetAll();
        //Async Method
        //Task <IEnumerable<Actor>> GetAllAsync();
        //Task <Actor> GetByIdAsync(int Id);
        //Task AddAsync(Actor actor);
        //Task <Actor> UpdateAsync(int Id, Actor newActor);
        //Task DeleteAsync(int Id);
    }
}
