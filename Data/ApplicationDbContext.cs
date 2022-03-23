using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FirstName> FirstNames { get; set; }
        public DbSet<ToSubscribe> ToSubscribes { get; set; }
        public DbSet<Twit> Twits { get; set; }
        public DbSet<DaTwit> DaTwits { get; set; }

        public DbSet<ToFollow> ToFollows { get; set; }
        
        
    }
}
