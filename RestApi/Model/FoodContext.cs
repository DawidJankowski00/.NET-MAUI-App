using Food.Model;
using Microsoft.EntityFrameworkCore;
using RestApi.Model;

namespace RestApi.Model
{
    public class FoodContext: DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Component> Components { get; set; } = null!;
        public DbSet<Article> Article { get; set; } = default!;
        public DbSet<Food.Model.User> User { get; set; } = default!;
        public DbSet<RestApi.Model.ComponentProduct> ComponentProduct { get; set; } = default!;
        public DbSet<RestApi.Model.UserComponent> UserComponent { get; set; } = default!;

    }
}
