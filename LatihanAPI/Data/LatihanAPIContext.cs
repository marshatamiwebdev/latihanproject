using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LatihanAPI.Models;

    public class LatihanAPIContext : DbContext
    {
        public LatihanAPIContext (DbContextOptions<LatihanAPIContext> options)
            : base(options)
        {
        }

        public DbSet<LatihanAPI.Models.MUser> MUser { get; set; }
    }
