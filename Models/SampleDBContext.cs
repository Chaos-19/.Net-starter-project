using Microsoft.EntityFrameworkCore;

namespace DotnetWebApiWithEFCodeFirst.Models
{
     public partial class SampleDBContext : DbContext
     {
       public SampleDBContext(DbContextOptions
       <SampleDBContext> options)
           : base(options)
       {
       }
       public virtual DbSet<Pizza> Pizza { get; set; }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.Entity<Pizza>(entity => {
               entity.HasKey(k => k.Id);
           });
           OnModelCreatingPartial(modelBuilder);
       }
       partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
     }
}