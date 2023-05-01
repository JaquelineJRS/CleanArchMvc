using CleanArchMvc.Dominio.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Dominio.Test
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParametes_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .NotThrow<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>()
                .WithMessage("Valor inválido para o Id, não pode ser menor do que zero.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pa", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido. O nome não pode conter menos que três caracteres.");
        }

        [Fact]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 99, "product image");
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

        [Fact]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionDescriptionName()
        {
            Action action = () => new Product(1, "Product Name", "Pa", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>()
                .WithMessage("Descrição inválida. O campo não pode conter menos que três caracteres.");
        }

        [Fact]
        public void CreateProduct_ShortPrinceValue_DomainExceptionPriceValue()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>()
                .WithMessage("O preço não pode ser negativo");
        }

        [Fact]
        public void CreateProduct_ShortStockValue_DomainExceptionStockValue()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, -99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>()
                .WithMessage("O estoque não pode ser negativo");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m,
                99, "product image toooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooogggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");

            action.Should()
                .Throw<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>()
                 .WithMessage("Nome da imagem muito longa, o máximo de 250 caracteres.");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should()
                .NotThrow<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should()
                .NotThrow<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>();
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, value, "product image");
            action.Should()
                .Throw<CleanArchMvc.Dominio.Validation.DomainExceptionValidation>()
                .WithMessage("O estoque não pode ser negativo");
        }
    }
}
