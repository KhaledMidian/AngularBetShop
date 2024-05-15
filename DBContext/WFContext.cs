using AngularBetShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AngularBetShop.DBContext
{
    public class WFContext:IdentityDbContext<AppUser>
    {
        public WFContext() : base()
        { }
        public WFContext(DbContextOptions<WFContext> options) : base(options)
        { }
        public DbSet<AppUser> appUsers { get; set; }
        public DbSet<Favorites> favorites  { get; set; }
        public DbSet<Category> categories  { get; set; }
        public DbSet<Cart> carts  { get; set; }
        public DbSet<Order> orders  { get; set; }
        public DbSet<Product> products  { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Favorites>()
                        .HasKey("appUserId", "productId");
            builder.Entity<Cart>()
                        .HasKey("productId", "orderId");
            base.OnModelCreating(builder);
        }


    }
}
