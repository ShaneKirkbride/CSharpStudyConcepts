using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpStudyConcepts
{
    public interface IProduct
    {
        string Operation();
    }

    // concrete products
    public class ConcreteProductA : IProduct
    {
        public string Operation() => "Result of ConcreteProductA";
    }

    public class ConcreteProductB : IProduct 
    {
        public string Operation() => "Result of ConcreteProductB"; 
    }

    // creator abstract class
    public abstract class  Creator
    {
        public abstract IProduct FactoryMethod();

        public string SomeOperation()
        {
            var product = FactoryMethod();
            return $"Creator: {product.Operation()}";
        }
    }

    public class ConcreteCreatorA : Creator
    {
        public override IProduct FactoryMethod() => new ConcreteProductA();
    }

    public class ConcreteCreatorB : Creator
    {
        public override IProduct FactoryMethod() => new ConcreteProductB();
    }

    public class ProductFactoryRegistry
    {
        private readonly Dictionary<string, Creator> creators = new();

        public void RegisterFactory(string productType, Creator creatorType)
        {
            creators[productType] = creatorType;
        }

        public IProduct CreateCreatior(string productType)
        {
            if (!creators.TryGetValue(productType, out var creator))
            {
                throw new ArgumentException($"Product type {productType} does not exist or is not registered");
            }
            return creator.FactoryMethod();
        }
    }
}
