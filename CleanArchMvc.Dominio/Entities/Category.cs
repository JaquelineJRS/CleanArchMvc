using System.Collections.Generic;

namespace CleanArchMvc.Dominio.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        //Neste caso estamos indicando que a classe categoria pode conter uma coleção de produtos
        public ICollection<Product> Products { get; set; }
    }
}
