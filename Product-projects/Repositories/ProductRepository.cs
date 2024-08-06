using Microsoft.Identity.Client;
using Product_projects.Context;
using Product_projects.Domains;
using Product_projects.Interfaces;

namespace Product_projects.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository()
        {
            _context = new ProductContext();
        }

        public void Create(Product newProduct)
        {
             try
            {
                _context.Product.Add(newProduct);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Guid Id)
        {
            try
            {
                var product = _context.Product.Find(Id);
                if (product != null)
                {
                    _context.Product.Remove(product);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product GetById(Guid Id)
        {
            try
            {
                return _context.Product.Find(Id) ?? throw new KeyNotFoundException("Product not found");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Product> ListProduct()
        {
            try
            {
                return _context.Product.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Guid Id, Product newProduct)
        {
            try
            {
                Product product = _context.Product.Find(Id)!;

                if (product != null)
                {
            
                    product.Name = newProduct.Name;
                    product.Price = newProduct.Price;
                    

                    _context.Product.Update(product);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

