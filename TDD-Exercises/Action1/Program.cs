using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var order = new Order()
            {
                Name = "Widget A",
                Price = 3.14m,
                Quantity = 100,
                Paid = false
            };

            List<Action<Order>> ListOfActions = new List<Action<Order>>();


            ListOfActions.Add((o) => o.Name = o.Name + " -In stock");
            ListOfActions.Add((o) => o.Price = o.Price * 1.25m);
            ListOfActions.Add((o) => o.Quantity = o.Quantity - 10);
            //ListOfActions.Add((o) => o.Name = "-Paid");
            ListOfActions.Add((o) => o.Paid = true);


            ProcessOrder(order, ListOfActions);

            Console.WriteLine(order.Name);
            if (order.Paid == true)
            {
                Console.WriteLine("OK");
            }
            Console.WriteLine(order.Price);
            Console.WriteLine(order.Quantity);
        }
       

        static void ProcessOrder(Order order, List<Action<Order>> action)
        {
            action.ForEach(a => a(order));
        }
        
       
        }
   
    }
  

