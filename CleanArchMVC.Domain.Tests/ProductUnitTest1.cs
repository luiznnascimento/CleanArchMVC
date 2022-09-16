using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validation;
using FluentAssertions;

namespace CleanArchMVC.Domain.Tests;

public class ProductUnitTest1
{
    [Fact]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        //Arrange
        const string name = "Product 1";
        const string description = "Product 1 Description";
        const decimal price = 9.99m;
        const int stock = 10;
        const string image = "image.png";

        //Act
        var product = new Product(name, description, price, stock, image);

        //Assert
        product.Should().NotBeNull();
        product.Name.Should().Be(name);
        product.Description.Should().Be(description);
        product.Price.Should().Be(price);
        product.Stock.Should().Be(stock);
        product.Image.Should().Be(image);
    }

    [Fact]
    public void CreateProduct_WithInvalidPrice_ThrowsDomainException()
    {
        //Arrange
        const string name = "Product 1";
        const string description = "Product 1 Description";
        const decimal price = -9.99m;
        const int stock = 10;
        const string image = "image.png";

        //Act
        var act = () =>
        {
            var product = new Product(name, description, price, stock, image);
        };

        //Assert
        act.Should().Throw<DomainExceptionValidation>();
        act.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price. Price must be greater than zero");
    }

    [Fact]
    public void CreateProduct_WithInvalidStock_ThrowsDomainException()
    {
        //Arrange
        const string name = "Product 1";
        const string description = "Product 1 Description";
        const decimal price = 9.99m;
        const int stock = -10;
        const string image = "image.png";

        //Act
        var act = () =>
        {
            var product = new Product(name, description, price, stock, image);
        };

        //Assert
        act.Should().Throw<DomainExceptionValidation>();
        act.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid stock. Stock must be greater than zero");
    }

    [Fact]
    public void CreateProduct_WithInvalidName_ThrowsDomainException()
    {
        //Arrange
        const string name = "";
        const string description = "Product 1 Description";
        const decimal price = 9.99m;
        const int stock = 10;
        const string image = "image.png";

        //Act
        var act = () =>
        {
            var product = new Product(name, description, price, stock, image);
        };

        //Assert
        act.Should().Throw<DomainExceptionValidation>();
        act.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
    }

    [Fact]
    public void CreateProduct_ShortDescriptionValue_DomainExceptionShortDescription()
    {
        //Arrange
        const string name = "Product 1";
        const string description = "TheD";
        const decimal price = 9.99m;
        const int stock = 10;
        const string image = "image.png";

        //Act
        var act = () =>
        {
            var product = new Product(name, description, price, stock, image);
        };

        //Assert
        act.Should().Throw<DomainExceptionValidation>();
        act.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid description, to short, minimum 5 characters");
    }

    [Fact]
    public void CreateProduct_WithInvalidImage_ThrowsDomainException()
    {
        //Arrange
        const string name = "Product 1";
        const string description = "Product 1 Description";
        const decimal price = 9.99m;
        const int stock = 10;
        const string image =
            "image____image____image____image____image____image____image____image___image____image___image____image____image____image___image____image____image____image____image____image____image____image___image____image___image____image____image____image_____image____image___image____image___image____image____image____image_____image____image___image____image___image____image____image____image_____image____image___image____image___image____image____image____image_";

        //Act
        var act = () =>
        {
            var product = new Product(name, description, price, stock, image);
        };

        //Assert
        act.Should().Throw<DomainExceptionValidation>();
        act.Should().Throw<DomainExceptionValidation>()
            .WithMessage("Invalid image. Image is too long, maximum 250 characters");
    }

    [Fact]
    public void CreateProduct_WithNullImageValue_NoNullReferenceException()
    {
        //Arrange
        const string name = "Product 1";
        const string description = "Product 1 Description";
        const decimal price = 9.99m;
        const int stock = 10;

        //Act
        var act = () =>
        {
            var product = new Product(name, description, price, stock, null);
        };
        
        //Assert
        act.Should().NotThrow<NullReferenceException>();
    }
}