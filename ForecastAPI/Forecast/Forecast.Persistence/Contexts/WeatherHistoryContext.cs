using Microsoft.EntityFrameworkCore;
using Forecast.Domain.Entities;

namespace Forecast.Persistence.Contexts
{
    public class HistoryContext : DbContext
    {
        public HistoryContext(DbContextOptions<HistoryContext> options) : base(options){
        }
        /// <summary>
        /// Defining the table and mapping contexts
        /// </summary>
        /// <param name="modelBuilder">(Internal)</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            _ = new HistoryMap(modelBuilder.Entity<History>());
        }
    }   
}
