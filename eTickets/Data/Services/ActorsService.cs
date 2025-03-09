using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorsService : EntityBsseRepository<Actor>, IActorsService
    { 
        
        public ActorsService(AppDbContext context):base(context) { }
       
        
    }
}
