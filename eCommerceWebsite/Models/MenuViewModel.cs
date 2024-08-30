namespace eCommerceWebsite.Models
{
    public class MenuViewModel
    {
        public MenuViewModel(List<CannedFood> food, int lastPage, int currentPage)
        {
            Food = food;
            LastPage = lastPage;
            CurrentPage = currentPage;
        }

        public List<CannedFood> Food { get; set; }

        /// <summary>
        /// The final page of the menu,
        /// calculated by having total products
        /// divided by products per page
        /// </summary>
        public int LastPage { get; set; }

        /// <summary>
        /// The current page the user is viewing
        /// </summary>
        public int CurrentPage { get; set; }
    }
}
