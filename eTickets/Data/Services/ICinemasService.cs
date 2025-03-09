using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface ICinemasService : IEntityBaseRepository<Cinema>
    {
        Task AddAsync(Cinema cinema);
        Task UpdateAsync(int id, Cinema cinema);
    }
}
