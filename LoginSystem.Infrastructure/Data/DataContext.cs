using LoginSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace LoginSystem.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Criar um usuário default com hash
            var hmac = new System.Security.Cryptography.HMACSHA512();
            var user = new LoginSystem.Domain.Entities.User
            {
                Id = 1,
                Username = "admin",
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("123456")),
                PasswordSalt = hmac.Key
            };

            modelBuilder.Entity<LoginSystem.Domain.Entities.User>().HasData(user);
        }

    }
}