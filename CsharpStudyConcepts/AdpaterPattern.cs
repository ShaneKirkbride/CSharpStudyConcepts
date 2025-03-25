using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpStudyConcepts
{
    public interface ITarget
    {
        string Request();
    }

    public class Adaptee
    {
        public string SpecificRequest() => "Specific behavior from Adaptee";
    }

    public class Adapter : ITarget
    {
        private readonly Adaptee adaptee;

        public Adapter(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }

        public string Request()
        {
            return adaptee.SpecificRequest();
        }
    }

    class AdapterDemo
    {
        public static void Adapt()
        {
            Adaptee adaptee = new Adaptee();
            ITarget adapter = new Adapter(adaptee);
            Console.WriteLine(adapter.Request());
        }
    }

}
