namespace CleanArchMvc.Dominio.Entities
{
    //Classes sealed não podem ser herdadas
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        //Aqui definimos a propriedade de navegação para que o EF entenda que é preciso criar uma tabela de relação entre as duas classes
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
