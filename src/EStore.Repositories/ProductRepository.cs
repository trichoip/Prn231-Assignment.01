using EStore.BusinessObject.Entities;
using EStore.DataAccess;
using EStore.DataAccess.DTOs;

namespace EStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDAO _productDAO;
        public ProductRepository(ProductDAO productDAO) => _productDAO = productDAO;

        public void DeleteProduct(Product p) => _productDAO.DeleteProduct(p);

        public Product GetProductByID(int id) => _productDAO.FindProductById(id);

        public List<ProductDTO> GetProducts(string search) => _productDAO.GetProducts(search);

        public void SaveProduct(ProductDTO p) => _productDAO.SaveProduct(p);

        public void UpdateProduct(int id, ProductDTO p) => _productDAO.UpdateProduct(id, p);
    }
}
