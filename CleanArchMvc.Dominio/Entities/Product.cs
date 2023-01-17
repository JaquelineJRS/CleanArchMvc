using CleanArchMvc.Dominio.Validation;

namespace CleanArchMvc.Dominio.Entities
{
    //Classes sealed não podem ser herdadas
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        //Aqui definimos a propriedade de navegação para que o EF entenda que é preciso criar uma tabela de relação entre as duas classes
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Valor inválido para o Id, não pode ser menor do que zero.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(int id, string name, string description, decimal price, int stock, string image, int categoryId)
        {            
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido. name.Name é obrigatório.");

            DomainExceptionValidation.When(name.Length < 3, "Nome inválido. O nome não pode conter menos que três caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Descrição inválida.");

            DomainExceptionValidation.When(description.Length < 3, "Descrição inválida. O campo não pode conter menos que três caracteres.");

            DomainExceptionValidation.When(price < 0, "O preço não pode ser negativo");

            DomainExceptionValidation.When(stock < 0, "O estoque não pode ser negativo");

            DomainExceptionValidation.When(image.Length < 250, "Nome da imagem muito longa, o máximo de 250 caracteres.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}
