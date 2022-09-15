using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validation;
using FluentAssertions;

namespace CleanArchMVC.Domain.Tests;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category With Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category 1");
        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category With Invalid Id")]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category 1");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }

    [Fact(DisplayName = "Create Category With Short Name")]
    public void CreateCategory_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Category(1, "Ca");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name, to short, minimum 3 characters");
    }

    [Fact(DisplayName = "Create Category With Empty Name")]
    public void CreateCategory_EmptyNameValue_DomainExceptionEmptyName()
    {
        Action action = () => new Category(1, "");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Create Category With Null Name")]
    public void CreateCategory_NullNameValue_DomainExceptionNullName()
    {
        Action action = () => new Category(1, null);
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }
}