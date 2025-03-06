using GloryScout.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GloryScout.ContextDB
{
	public class AppDBContext : DbContext
	{

		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
		{
		}

		public DbSet<User> User { get; set; }
		public DbSet<Posts> Posts { get; set; }
		public DbSet<Likes> Likes { get; set; }
		public DbSet<Comments> Comments { get; set; }
		public DbSet<vertificationCodes> vertificationCodes { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
	
			// to create roles in  the database . seed initial data for ASP.NET Core Identity roles into the database. // they will be static for now
			modelBuilder.Entity<IdentityRole>().HasData(
				new IdentityRole()
				{
					Id = "3f1f5e7a-8c2d-4b8f-9b5e-2c7a5e5f1e6d", // Static GUID
					Name = "Admin",
					NormalizedName = "admin",
					ConcurrencyStamp = "a1f5e7b2-3c2d-4b8f-9b5e-2c7a5e5f1e6d" // Static GUID
				},
			   new IdentityRole()
			   {
				   Id = "4a2f6e8b-9d3e-5c9f-0c6f-3d8b6f6f2f7e", // Static GUID
				   Name = "Player",
				   NormalizedName = "player",
				   ConcurrencyStamp = "b2f6e8c3-4d3e-5c9f-0c6f-3d8b6f6f2f7e" // Static GUID
			   },
			   new IdentityRole()
			   {
				   Id = "5b3f7f9c-0e4f-6d1f-1d7f-4e9c7g7g3g8f", // Static GUID
				   Name = "Scout",
				   NormalizedName = "scout",
				   ConcurrencyStamp = "c3f7f9d4-5e4f-6d1f-1d7f-4e9c7g7g3g8f" // Static GUID
			   }
			   );

			// Configure Posts and Comments relationship
			modelBuilder.Entity<Comments>()
				.HasOne(c => c.Posts)
				.WithMany(p => p.Comments)
				.HasForeignKey(c => c.PostId)
				.OnDelete(DeleteBehavior.Cascade); // or DeleteBehavior.Restrict

			// Configure Users and Comments relationship
			modelBuilder.Entity<Comments>()
				.HasOne(c => c.User)
				.WithMany(u => u.Comments)
				.HasForeignKey(c => c.UserID)
				.OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.SetNull

			// Configure Posts and Likes relationship
			modelBuilder.Entity<Likes>()
				.HasOne(l => l.Posts)
				.WithMany(p => p.Likes)
				.HasForeignKey(l => l.PostId)
				.OnDelete(DeleteBehavior.Cascade); // Retain cascade delete

			// Configure Users and Likes relationship
			modelBuilder.Entity<Likes>()
				.HasOne(l => l.User)
				.WithMany(u => u.Likes)
				.HasForeignKey(l => l.UserId)
				.OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

			base.OnModelCreating(modelBuilder);
		}


	}
}
