using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using netflixAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace netflixAPI.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<ProgramTable> Programs { get; set; }

        public DbSet<Types> Types { get; set; }

        public DbSet<UserProgramTable> UserPrograms { get; set; }
        public DbSet<ProgramTypeTable> ProgramTypes { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}

