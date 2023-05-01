# CleanArchMvc
Solução desenvolvida durante o curso sobre Clean Architecture com o objetivo de mostrar na prática os conceitos de uma arquitetura limpa.

<img height="100" width="100" src="https://user-images.githubusercontent.com/69124311/235538350-f3729324-5475-45bb-8e35-547a3eea227f.png" alt="Ícone teste unitário" />


## 🛠️ Tecnologias
* **.NET**: Constam duas versões do projeto, uma que utiliza o .NET 6 disponível na branch *main* e *versions/dotnet-6.0*, e outra com .NET 5 disponínel na branch *versions/dotnet-5.0*;
* **ASP.NET Core**: O projeto Web.UI foi desenvolvido em padrão MVC;
* **Identify**: A autenticação do projeto Web.UI ocorre através da implementação do Identity;
* **JWT**: A autenticação do projeto da API ocorre através da implementação do JWT;
* **EF Core**: Utilizado para a construção e acesso aos dados da aplicação;

## 🗃️ Arquitetura
* A arquitetura foi construída com base na teoria de camadas, onde a longo prazo facilita a escalabilidade e manutenção do código;
* Inversão e Injeção de Dependências;
* Separação das responsabilidades com a construção de projetos individuais;
  * projs: Dominio/ Application/ Infra.Data/ Infra.IoC/ Domain/Test/ Web.Ui e API;
  
## 📚 Padrões e Conceitos
* Foi implementado alguns conceitos de Domain Drive Design(DDD);
* Padrão de Repository
* Padrão CQRS

## <img height="30" width="40" src="https://user-images.githubusercontent.com/69124311/235537391-3bb5d6e4-62dd-437d-81ce-e3b007e5f58f.png" alt="Ícone teste unitário" /> Teste unitário
### Tecnologia: xUnit
* No projeto Domain.Test foram implementados testes unitários com o objetivo de inicialização ao conceito de TDD.
