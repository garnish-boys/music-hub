﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data
{
    public class MusicHubDbContext : IdentityDbContext<User, Role, string>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectPermissions> ProjectPermissions { get; set; }


        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}