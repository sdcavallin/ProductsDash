using Bogus;
using FirstWebAppMVC.Models;

namespace FirstWebAppMVC.Services
{
    public class HardcodedSampleDataRepository : IProductDataService
    {
        static List<ProductModel> list = new List<ProductModel>();

        public ProductModel Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProducts()
        {
            
            if(list.Count == 0)
            {
                list.Add(new ProductModel { Id = 1, Name = "Mouse Pad", Price = 5.00m, Description = "A square piece of plastic" });
                list.Add(new ProductModel { Id = 2, Name = "Webcam", Price = 8.99m, Description = "Camera for computer" });
                list.Add(new ProductModel { Id = 3, Name = "4 TB USB Drive", Price = 40.00m, Description = "Storage" });
                list.Add(new ProductModel { Id = 4, Name = "Wireless Mouse", Price = 6.49m, Description = "Mouse with no wire" });

                for (int i = 0; i < 100; i++)
                {
                    list.Add(new Faker<ProductModel>()
                        .RuleFor(p => p.Id, i + 5)
                        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                        .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                        .RuleFor(p => p.Description, f => f.Rant.Review())
                        );
                }
            }


            return list;
        }

        public ProductModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public ProductModel Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> Search(string query)
        {
            throw new NotImplementedException();
        }

        public ProductModel Update(ProductModel product)
        {
            throw new NotImplementedException();
        }

        int IProductDataService.Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        int IProductDataService.Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        int IProductDataService.Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
