using System;
using API.Domain.Entities;
using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<AnuncioEntity> Anuncios { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AnuncioEntity>(new AnuncioMap().Configure);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);


        }


    }
}
