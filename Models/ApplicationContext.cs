﻿using Microsoft.EntityFrameworkCore;
using ThanksCardAPI.Controllers;
using ThanksCardAPI.Models;

namespace ThanksCardAPI.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<ThanksCard> ThanksCards{ get; set; }
        public DbSet<ThanksCardAPI.Models.Tag> Tag { get; set; }
    }
}
