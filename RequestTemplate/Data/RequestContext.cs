using Microsoft.EntityFrameworkCore;
using RequestTemplate.Models;

namespace RequestTemplate.Models
{
    public class RequestContext : DbContext
    {
        public RequestContext (DbContextOptions<RequestContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Request>().HasOne(src => src.FlowId).WithOne();
        }

        public DbSet<RequestTemplate.Models.Node> Node { get; set; }

        public DbSet<RequestTemplate.Models.NodeCreateModel> NodeCreateModel { get; set; }

        public DbSet<RequestTemplate.Models.Role> Role { get; set; }
    }
}
