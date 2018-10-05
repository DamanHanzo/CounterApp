using Microsoft.EntityFrameworkCore;

namespace CounterApp.Models {
    public class CounterContext: DbContext
    {
        public CounterContext(DbContextOptions<CounterContext> options)
            : base(options)
        {}

        public DbSet<Counter> Counters {get; set;}
    }
}