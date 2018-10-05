using Microsoft.EntityFrameworkCore;

namespace CounterApp.Models {
    public class CounterContext: DbContext
    {
        public CounterContext(DbContextOptions<CounterContext> options)
            : base(options)
        {}

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Counter>()
        //         .Property(p => p.id)
        //         .ValueGeneratedOnAdd();
        // }

        public DbSet<Counter> Counters {get; set;}
    }
}