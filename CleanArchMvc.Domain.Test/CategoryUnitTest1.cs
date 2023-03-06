using CleanArchMvc.Dominio.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Test
{
    public class CategoryUnitTest1
    {
        //Teste para a cria��o de categoria com estado v�lido
        [Fact(DisplayName ="Create Category With Valid State")]
        public void CreateCategory_WithValidParametes_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>();
        }

        //teste para validar a cria��o da categoria quando esta receber o valor do id inv�lido
        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>()
                .WithMessage("Valor inv�lido para o Id, n�o pode ser menor do que zero.");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inv�lido. O nome n�o pode conter menos que tr�s caracteres.");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inv�lido. name.Name � obrigat�rio.");
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
