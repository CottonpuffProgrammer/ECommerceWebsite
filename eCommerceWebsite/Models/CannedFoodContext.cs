using Microsoft.EntityFrameworkCore;

namespace eCommerceWebsite.Models
{
    public class CannedFoodContext : DbContext
    {
        public CannedFoodContext(DbContextOptions<CannedFoodContext> options) : base(options)
        {

        }

        public DbSet<CannedFood> cannedFoods { get; set; }
    }
}
