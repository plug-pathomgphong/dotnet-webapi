using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dotnet_webapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasData(
                new Skill{ Id = 1, Name = "Fireball", Damage = 30},
                new Skill{ Id = 2, Name = "Frenzy", Damage = 20},
                new Skill{ Id = 3, Name = "Blizzard", Damage =  50}
            );

            modelBuilder.Entity<User>().Property(user => user.Role).HasDefaultValue("Player");
        }
        public DbSet<Charactor> Charactors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Weapons> Weapons { get; set; }

        public DbSet<Skill> Skills { get; set; }

    }
}