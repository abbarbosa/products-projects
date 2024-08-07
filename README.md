# products-projects

## Sobre o Projeto

### Este projeto desenvolvido para fins educacionais é uma API para gerenciar produtos, incluindo operações CRUD (Create, Read, Update, Delete). A API é desenvolvida utilizando ASP.NET Core e Entity Framework Core, e está configurada para se conectar a um banco de dados SQL Server. O projeto também inclui testes de unidade usando xUnit e Moq. Vale ressaltar que o projeto foi desenvolvido utilizando o método CodeFirst(Modelo que se segue o padrão de primeiro o código e depois o banco)

## Estrutura do projeto 

### A estrutura do projeto foi desenvolvida da seguinte maneira:

### Domains: contém as classes de modelo, que são usadas para mapear as tabelas do banco de dados para objetos C# .

### Context: gerenciar a conexão com o banco de dados e fornecer um meio para realizar operações de CRUD nos modelos de dados

### Interfaces: especificam os métodos que os repositórios devem implementar

### Repositories : contém as implementações dos repositórios, que são responsáveis pela interação com o banco de dados. 

### Controllers : os controladores são responsáveis por manipular e realizar operações de CRUD e retornar respostas para o cliente.


## Endpoints da API

### GET /api/product: Lista todos os produtos.
### GET /api/product/{id}: Obtém um produto por ID.
### POST /api/product: Cria um novo produto.
### PUT /api/product/{id}: Atualiza um produto existente.
### DELETE /api/product/{id}: Exclui um produto por ID.


## Swagger

### conjunto de ferramentas e especificações para descrever, consumir e visualizar APIs


