using System.ComponentModel.DataAnnotations;

namespace eCommerceWebsite.Models
{
    /// <summary>
    /// Prepresents a single canned food item
    /// </summary>
    public class CannedFood
    {
        /// <summary>
        /// Uniquely identifies each canned food item
        /// </summary>
        [Key]
        public int FoodId { get; set; }

        /// <summary>
        /// Name of the canned food
        /// </summary>
        [Required]
        public string FoodName { get; set; }

        /// <summary>
        /// Sales price of the food
        /// </summary>
        [Range(0, 1000)]
        public double FoodPrice { get; set; }

        // To Do: Add rating
    }
}
