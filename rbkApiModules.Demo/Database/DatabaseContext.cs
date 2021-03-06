﻿using Microsoft.EntityFrameworkCore;
using rbkApiModules.Authentication;
using rbkApiModules.Comments;
using rbkApiModules.Demo.Models;
using rbkApiModules.Utilities.Extensions;

namespace rbkApiModules.Demo.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurations(new [] 
            {
                typeof(DatabaseContext).Assembly,
                typeof(CommentEntity.Command).Assembly,
                typeof(UserLogin.Command).Assembly,
            });
        } 
    }
}
