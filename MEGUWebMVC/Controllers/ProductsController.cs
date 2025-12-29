using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MEGUWebMVC.Data;
using MEGUWebMVC.Models.Helpers;
using MEGUWebMVC.Models.Product;
using System.Threading.Tasks;

namespace MEGUWebMVC.Controllers
{
    public class ProductsController(AppDbContext context, IMapper mapper) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(ProductSearchViewModel searchModel)
        {
            ViewBag.Title = "Фільми";

            searchModel.Categories = await mapper
                .ProjectTo<SelectItemViewModel>(context.Categories)
                .ToListAsync();

            searchModel.Categories.Insert(0, new SelectItemViewModel
            {
                Id = 0,
                Name = "Всі категорії"
            });

            var query = context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(searchModel.Name))
            {
                string textSearch = searchModel.Name.Trim().ToLower();
                query = query.Where(p => p.Name.ToLower().Contains(textSearch));
            }

            if (!string.IsNullOrEmpty(searchModel.Description))
            {
                string textSearch = searchModel.Description.Trim().ToLower();
                query = query.Where(p => p.Description.ToLower().Contains(textSearch));
            }

            if (searchModel.CategoryId != 0)
            {
                query = query.Where(p => p.CategoryId == searchModel.CategoryId);
            }

            int itemsPerPage = searchModel.Pagination.ItemsPerPage;
            int totalItems = await query.CountAsync();
            searchModel.Pagination.TotalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);
            searchModel.Pagination.TotalItems = totalItems;

            searchModel.Pagination.CurrentPage = Math.Clamp(searchModel.Pagination.CurrentPage, 0, searchModel.Pagination.TotalPages);

            if (totalItems <= itemsPerPage)
                searchModel.Pagination.CurrentPage = 1;

            var products = await query
                .Skip((searchModel.Pagination.CurrentPage - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ProjectTo<ProductItemViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            var model = new ProductListViewModel
            {
                Products = products,
                Search = searchModel,
            };

            return View(model);
        }
    }
}
