using System;
using Microsoft.EntityFrameworkCore;
using SEDC.Loto3000App.Domain.Enums;
using SEDC.Loto3000App.Domain.Models;

namespace SEDC.Loto3000App.DataAcces
{
	public class LotoAppDbContext : DbContext
	{
		public LotoAppDbContext(DbContextOptions options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Loto> Lotos{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Game

            modelBuilder.Entity<Loto>()
                .Property(x => x.Numbers)
                .HasMaxLength(37)
                .IsRequired();

            modelBuilder.Entity<Loto>()
                .Property(x => x.Prize)
                .IsRequired();

          

            modelBuilder.Entity<Loto>()
                .Property(X => X.Session)
                .IsRequired();


            modelBuilder.Entity<Loto>()
                .HasOne(x => x.User)
                .WithMany(x => x.Lotos)
                .HasForeignKey(x => x.UserId);


            //User

            modelBuilder.Entity<User>()
                .Property(x => x.FirstName)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .HasMaxLength(50);


            modelBuilder.Entity<User>()
                .Property(x => x.UserName)
                .HasMaxLength(30)
                .IsRequired();


            //Admin

            modelBuilder.Entity<Admin>()
                .Property(x => x.FirstName)
                .HasMaxLength(50);


            modelBuilder.Entity<Admin>()
                .Property(x => x.LastName)
                .HasMaxLength(50);


            modelBuilder.Entity<Admin>()
                .Property(x => x.AdminName)
                .HasMaxLength(30)
                .IsRequired();

            //SEED


            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    FirstName = "Teo",
                    LastName = "Mladenov",
                    UserName = "tmladenov",
                    Age = 23

                });


            modelBuilder.Entity<Loto>()
                .HasData(new Loto
                {
                    Numbers = 4,
                    Prize = Prize.GiftCard100,
                    Session = Session.First,
                    UserId = 1

                });

            modelBuilder.Entity<Admin>()
                .HasData(new Admin
                {
                    Id = 1,
                    FirstName = "Dejan",
                    LastName = "Mladenov",
                    AdminName = "Dmladenov"
                    

                });










        }

    }
}

