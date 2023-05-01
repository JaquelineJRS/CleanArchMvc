using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;

namespace CleanArchMvc.Domain.Entities
{
    //Classes sealed não podem ser herdadas
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        //Neste caso estamos indicando que a classe categoria pode conter uma coleção de produtos
        //public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }        

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Valor inválido para o Id, não pode ser menor do que zero.");
            Id = id;
            ValidateDomain(name);
        }
        
        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido. name.Name é obrigatório.");

            DomainExceptionValidation.When(name.Length < 3, "Nome inválido. O nome não pode conter menos que três caracteres.");

            Name = name;
        }
    }
}
