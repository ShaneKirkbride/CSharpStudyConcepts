using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpStudyConcepts
{
    public interface IObserver
    {
        void Update(string message);
    }

    public class Customer : IObserver
    {
        public string Name { get; set; }

        public Customer(string name)
        {
            this.Name = name;
        }
        public void Update(string message)
        {
            Console.WriteLine($"{Name} {message}");
        } 
    }

    public class Store
    {
        private List<IObserver> customer = new List<IObserver>();

        public void AddCustomer(IObserver observer)
        {
            customer.Add(observer);
        }

        public void Notify(string message)
        {
            foreach (var customer in customer)
            {
                customer.Update(message);
            }
        }

        public void NewArrival(string item)
        {
            Notify($"Item {item}");
        }
    }


    internal class ObserverPattern
    {
        public static int ObserverPatternDemo()
        {

            return 0;
        }

    }
}
