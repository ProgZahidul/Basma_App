
    using System.Collections.Generic;
using Basma_App.Models;
using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ContactViewModel> Contacts { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
}


