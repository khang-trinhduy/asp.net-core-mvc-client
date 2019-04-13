using Microsoft.EntityFrameworkCore;

namespace RequestTemplate.Models
{
    public class RequestContext : DbContext
    {
        public RequestContext (DbContextOptions<RequestContext> options)
            : base(options)
        {
        }

        public DbSet<RequestTemplate.Models.Request> Requests { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<WorkFlow> Flows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Request>().HasOne(src => src.FlowId).WithOne();
        }
    }
}
