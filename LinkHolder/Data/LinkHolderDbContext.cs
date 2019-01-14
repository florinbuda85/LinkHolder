using LinkHolder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkHolder.Data
{
    public class LinkHolderDbContext : DbContext
    {
        public LinkHolderDbContext(DbContextOptions options) : base (options)
        {
            //todo
        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Link> Links { get; set; }
        //public DbSet<LinkTag> LinkTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<LinkTag>()
                    .HasKey(bc => new { bc.LinkId, bc.TagId });

            modelBuilder.Entity<LinkTag>()
                .HasOne(bc => bc.Link)
                .WithMany(b => b.LinkTags)
                .HasForeignKey(bc => bc.LinkId);

            modelBuilder.Entity<LinkTag>()
                .HasOne(bc => bc.Tag)
                .WithMany(c => c.LinkTags)
                .HasForeignKey(bc => bc.TagId);
        }
    }
}
