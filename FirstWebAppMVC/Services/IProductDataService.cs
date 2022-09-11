using FirstWebAppMVC.Models;

namespace FirstWebAppMVC.Services
{
    public interface IProductDataService
    {

        List<ProductModel> GetAllProducts();
        List<ProductModel> Search(string query);
        ProductModel GetProductById(int id);
        int Insert(ProductModel product);
        int Update(ProductModel product);
        int Delete(ProductModel product);

    }
}
