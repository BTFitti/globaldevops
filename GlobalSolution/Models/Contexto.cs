using Microsoft.EntityFrameworkCore;

namespace GlobalSolution.Models
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Radar> Radar { get; set; }
    }
}
