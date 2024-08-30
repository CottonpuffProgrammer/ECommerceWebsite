using Microsoft.EntityFrameworkCore;
using eCommerceWebsite.Models;

namespace eCommerceWebsite.Models
{
    public class CannedFoodContext : DbContext
    {
        public CannedFoodContext(DbContextOptions<CannedFoodContext> options) : base(options)
        {

        }

        public DbSet<CannedFood> cannedFoods { get; set; }

        public DbSet<Member> members { get; set; }
        public DbSet<eCommerceWebsite.Models.LoginViewModel> LoginViewModel { get; set; } = default!;
    }
}
