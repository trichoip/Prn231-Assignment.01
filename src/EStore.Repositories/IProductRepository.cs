using EStore.BusinessObject.Entities;
using EStore.DataAccess.DTOs;

namespace EStore.Repositories
{
    public interface IProductRepository
    {
        void SaveProduct(ProductDTO p);

        Product GetProductByID(int id);

        void DeleteProduct(Product p);

        void UpdateProduct(int id, ProductDTO p);

        List<ProductDTO> GetProducts(string search);
    }
}
