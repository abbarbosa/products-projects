using Moq;
using Product_projects.Domains;
using Product_projects.Interfaces;
using Product_projects.Repositories;
using Xunit;

namespace TextProject
{
    public class TestProject
    {
        //indica que o metodo é de teste
        [Fact]
        public void get()
        {
            //Arrange : organizar

            var product = new List<Product>
           {
               new Product {IdProduct = Guid.NewGuid(),Name = "Product 1", Price = 100 },
               new Product {IdProduct = Guid.NewGuid(),Name = "Product 2", Price = 1000 },
               new Product {IdProduct = Guid.NewGuid(),Name = "Product 3", Price = 10000 }
            };


            //cria um obj de simulação do tipo repositório
            var mockRepository = new Mock<IProductRepository>();

            //config o metodo GetProducts para retornar a lista de produtos mock
            mockRepository.Setup(x => x.ListProduct()).Returns(product);


            //Act : agir

            //chama o metodo getProducts e armazena o resultado em result
            var result = mockRepository.Object.ListProduct();

            //assert

            //prova se o resuktado esperado é igual ao resultado obtido através da busca
            Assert.Equal(3, result.Count);


        }

        [Fact]
        public void Post()
        {
            //Arrange 

            Product product = new Product { IdProduct = Guid.NewGuid(),Name = "Product 5", Price = 100 };

            var productList = new List<Product>();

            var mockRepository = new Mock<IProductRepository>();

            mockRepository.Setup(x=> x.Create(product)).Callback<Product>(x=>productList.Add(product));

            //Act

            mockRepository.Object.Create(product);

            //Assert

            Assert.Contains(product, productList);




           /* //Arrange
            
            //variavel que cria novo produto
            var newProduct = new Product { IdProduct = Guid.NewGuid(), Name = "Product 4", Price = 500 };


            //obj de simulacao do tipo IProductsRepository
            var mockPostRepository = new Mock<IProductRepository>();

            mockPostRepository.Setup(x => x.Create(It.IsAny<Product>())).Verifiable();


            //Act

            
            mockPostRepository.Object.Create(newProduct);

            //Assert

            
            mockPostRepository.Verify(x=> x.Create(newProduct));*/
        }


        [Fact]
        public void Delete()
        {
            //Arrange



            //Act

            //Assert
        }


    }

}