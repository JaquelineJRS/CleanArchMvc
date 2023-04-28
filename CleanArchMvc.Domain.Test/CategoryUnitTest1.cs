using CleanArchMvc.Dominio.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Test
{
    public class CategoryUnitTest1
    {
        //Teste para a criação de categoria com estado válido
        [Fact(DisplayName ="Create Category With Valid State")]
        public void CreateCategory_WithValidParametes_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>();
        }

        //teste para validar a criação da categoria quando esta receber o valor do id inválido
        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>()
                .WithMessage("Valor inválido para o Id, não pode ser menor do que zero.");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido. O nome não pode conter menos que três caracteres.");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido. name.Name é obrigatório.");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>();
        }
    }
}
