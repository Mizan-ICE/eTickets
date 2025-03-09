using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class ProducersService:EntityBsseRepository<Producer>,IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        {
            
        }
    }
}
