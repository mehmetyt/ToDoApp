using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Data
{
	public class UygulamaDbContext:DbContext
	{
		public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options)
		{

		}

		public DbSet<toDo> ToDos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<toDo>().HasData(
				new toDo() { Id=1,Title= "Buy groceries", Done=false},
				new toDo() { Id=2,Title= "Complete homework", Done=true},
				new toDo() { Id=3,Title= "Go for a run", Done=true},
				new toDo() { Id=4,Title= "Read a book", Done=false}
				);
		}
	}
}
