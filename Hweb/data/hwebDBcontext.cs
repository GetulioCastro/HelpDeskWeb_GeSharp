using Microsoft.EntityFrameworkCore;
using Hweb;
    
namespace Hweb.data
{
    public class hwebDBcontext : DbContext
    {
        public hwebDBcontext(DbContextOptions<hwebDBcontext> options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<userRequests>()
                .HasKey(c => new { c.requestID, c.username });
        }

        public DbSet<Login_Credentials> Login_Credentials { get; set; }

        public DbSet<Hweb.Requests>? Requests { get; set; }
        public DbSet<Hweb.userRequests>? userRequests { get; set; }
        public DbSet<Hweb.completed_request_log>? completed_request_log { get; set; }
    }
}
