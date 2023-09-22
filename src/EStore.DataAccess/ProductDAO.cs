using EStore.BusinessObject.Data;
using EStore.BusinessObject.Entities;
using EStore.DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EStore.DataAccess
{
    public class ProductDAO
    {
        private readonly FstoreDbContext _context;

        public ProductDAO(FstoreDbContext context) => _context = context;

        public List<ProductDTO> GetProducts(string search)
        {
            var products = _context.Products.Include(p => p.Category).Select(prd => new ProductDTO
            {
                ProductId = prd.ProductId,
                ProductName = prd.ProductName,
                Weight = prd.Weight,
                UnitPrice = prd.UnitPrice,
                UnitsInStock = prd.UnitsInStock,
                CategoryId = prd.CategoryId,
            });

            try
            {

                if (!string.IsNullOrEmpty(search))
                {
                    products = products.Where(p => p.ProductName.ToLower().Contains(search.ToLower()));
                }
                else
                {
                    products = products;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return products.ToList();
        }

        public Product FindProductById(int pid)
        {
            Product p = new Product();
            try
            {
                p = _context.Products.SingleOrDefault(p => p.ProductId == pid);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }

        public void SaveProduct(ProductDTO productRespond)
        {
            try
            {
                var product = new Product
                {
                    ProductName = productRespond.ProductName,
                    Weight = productRespond.Weight,
                    UnitPrice = productRespond.UnitPrice,
                    UnitsInStock = productRespond.UnitsInStock,
                    CategoryId = productRespond.CategoryId,
                };
                _context.Products.Add(product);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProduct(int id, ProductDTO productRespond)
        {
            try
            {
                var productUpdate = _context.Products.SingleOrDefault(p => p.ProductId == id);
                productUpdate.ProductName = productRespond.ProductName;
                productUpdate.Weight = productRespond.Weight;
                productUpdate.UnitPrice = productRespond.UnitPrice;
                productUpdate.UnitsInStock = productRespond.UnitsInStock;
                productUpdate.CategoryId = productRespond.CategoryId;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProduct(Product product)
        {
            try
            {
                var p1 = _context.Products.SingleOrDefault(c => c.ProductId == product.ProductId);
                _context.Products.Remove(p1);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
