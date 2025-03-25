using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CsharpStudyConcepts
{
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }

    public class SimpleCoffee : ICoffee
    {
        public string GetDescription() => "Simple Coffee";
        public double GetCost() => 1.0;
    }

    public abstract class CoffeeDecorator : ICoffee
    {
        protected readonly ICoffee _coffee;

        public CoffeeDecorator(ICoffee coffee) => this._coffee = coffee;
        public virtual string GetDescription() => this._coffee.GetDescription();
        public virtual double GetCost()=>this._coffee.GetCost();
    }

    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }
        public override string GetDescription() => this._coffee.GetDescription() + ", Milk";
        public override double GetCost() => this._coffee.GetCost() + 0.5;
    }

    public class SugarDecoator : CoffeeDecorator
    {
        public SugarDecoator(ICoffee coffee) : base(coffee) { }
        public override string GetDescription() => this._coffee.GetDescription() + ", Sugar";
        public override double GetCost() => this._coffee.GetCost() + 0.2;
    }

    internal class DecoratorPattern
    {
        public static void DecoratorPatternDemo()
        {
            ICoffee coffee = new SimpleCoffee();
            coffee = new MilkDecorator(coffee);
            coffee = new SugarDecoator(coffee);
            Console.WriteLine($"{coffee.GetDescription()} costs: {coffee.GetCost()}");
        }
    }
}
