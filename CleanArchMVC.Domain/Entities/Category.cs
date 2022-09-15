using CleanArchMVC.Domain.Validation;

namespace CleanArchMVC.Domain.Entities;

public sealed class Category
{
   public int Id { get; private set;  }
   public string Name { get; private set;  }

   public Category(string name)
   {
      ValidateDomain(name);
   }


   public Category(int id, string name)
   {
      DomainExceptionValidation.When(Id < 0, "Invalid Id value");
      Id = id;
      ValidateDomain(name);
   }
   
   public ICollection<Product> Products { get; private set; }

   private void ValidateDomain(string name)
   {
      DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
      DomainExceptionValidation.When(name.Length < 3, "Invalid name, to short, minimum 3 characters");
      Name = name;
   }
   
}