using Product_projects.Domains;

namespace Product_projects.Interfaces
{
    public interface IProductRepository 
    {
        List<Product> ListProduct();

        Product GetById(Guid Id);

        void Create(Product newProduct);

        void Update(Guid Id , Product newProduct);

        void Delete(Guid Id);
    }
}
