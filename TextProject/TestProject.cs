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
        public void Get()
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

            Product product = new Product { IdProduct = Guid.NewGuid(), Name = "Product 5", Price = 100 };

            var productList = new List<Product>();

            var mockRepository = new Mock<IProductRepository>();

            mockRepository.Setup(x => x.Create(product)).Callback<Product>(x => productList.Add(product));

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

            //para identificar o produto a ser deletado
            var productId = Guid.NewGuid();

            //cria lista com produtos
            var productList = new List<Product>
            {
                new Product { IdProduct = productId, Name = "Product 1", Price = 100 },
                new Product { IdProduct = Guid.NewGuid(), Name = "Product 2", Price = 1000 },
                new Product { IdProduct = Guid.NewGuid(), Name = "Product 3", Price = 10000 }
            };

            //cria simulação
            var mockRepository = new Mock<IProductRepository>();

            //Configura o método Delete do mock para remover um produto da lista quando chamado
            mockRepository.Setup(x => x.Delete(It.IsAny<Guid>()))
                         .Callback<Guid>(id =>
                         {
                             var productToRemove = productList.FirstOrDefault(p => p.IdProduct == id);
                             if (productToRemove != null)
                             {
                                 productList.Remove(productToRemove);
                             }
                         });



            //Act

            //chama o metodo delete com o id do produto que vai deletar
            mockRepository.Object.Delete(productId);

            //Assert

            //verifica se a lista de produtos não contém mais o produto removido
            Assert.DoesNotContain(productList, p => p.IdProduct == productId);

            //verifica se agora tem dois produtos na lista
            Assert.Equal(2, productList.Count);
        }


        [Fact]
        public void Update()
        {
            //Arrange

            //gera um novo guid
            var productId = Guid.NewGuid();

            //cria um novo produto
            var product = new Product { IdProduct = productId, Name = "Produto", Price = 5 };
            var productAtt = new Product { IdProduct = productId, Name = "ProdutoAtualizado", Price = 50 };

            //cria uma simulacao
            var mockRepository = new Mock<IProductRepository>();

            // Configura o mock para esperar uma chamada ao método Update com os parâmetros productId e productAtt.
            // Marca esta configuração como verificável.
            mockRepository.Setup(x => x.Update(productId, productAtt)).Verifiable();

            //Act

            //Chama o método Update no objeto mock, passando os parâmetros productId e productAt
            mockRepository.Object.Update(productId, productAtt);
            
            //Assert

            //verifica de o metodo update doi chamado
            mockRepository.Verify(x => x.Update(productId, productAtt), Times.Once);
        }


    }

}