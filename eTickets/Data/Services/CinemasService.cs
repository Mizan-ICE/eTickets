using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class CinemasService:EntityBsseRepository<Cinema>,ICinemasService
    {
        public CinemasService(AppDbContext context):base(context)
        {
            
        }
    }
}
