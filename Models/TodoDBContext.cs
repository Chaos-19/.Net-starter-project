using Microsoft.EntityFrameworkCore;
using simple_todoapi.Models;

namespace simple_todoapi.Models
{
     public partial class TodoDBContext : DbContext
     {
       public TodoDBContext(DbContextOptions
       <TodoDBContext> options)
           : base(options)
       {
       }
       public virtual DbSet<Todo> Todo { get; set; }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.Entity<Todo>(entity => {
               entity.HasKey(k => k.Id);
           });
           OnModelCreatingPartial(modelBuilder);
       }
       partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
     }
}