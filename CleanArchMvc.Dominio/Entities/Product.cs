namespace CleanArchMvc.Dominio.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }

        //Aqui definimos a propriedade de navegação para que o EF entenda que é preciso criar uma tabela de relação entre as duas classes
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
