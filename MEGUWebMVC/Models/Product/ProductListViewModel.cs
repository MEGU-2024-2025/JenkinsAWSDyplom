using MEGUWebMVC.Models.Helpers;

namespace MEGUWebMVC.Models.Product
{
    public class ProductListViewModel
    {
        public List<ProductItemViewModel> Products { get; set; } = new();
        public ProductSearchViewModel Search { get; set; } = new();
    }
}
