using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApp.Models.Models;

namespace TodoApp.Data.Models
{
    public class TodoGroupContext : DbContext
    {

        public TodoGroupContext(DbContextOptions<TodoGroupContext> options)
            : base(options)
        {
        }
        public DbSet<TodoGroup> TodoGroup { get; set; }
        public DbSet<TodoItem> TodoItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new TodoGroupConfiguration());
        }
    }

    public class TodoGroupConfiguration : IEntityTypeConfiguration<TodoGroup>
    {
        public void Configure(EntityTypeBuilder<TodoGroup> builder)
        {
            builder.ToTable("TodoGroup").HasKey(a => a.Id);
            builder.HasMany(x => x.TodoItems).WithOne();
        }
    }

    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("TodoItem").HasKey(a => a.Id);
        }
    }
}
