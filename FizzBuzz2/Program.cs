using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz2
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] fizzbuzzArray = { 1, 2, 3, 4, 5, 6, 15, 30 };

            //Creates a new list
            ListWithChangedEvents list = new ListWithChangedEvents();

            //Creates a class that listens for when the list is changed
            EventListener listener = new EventListener(list);

            //Print the initial array
            for (int i = 0; i < fizzbuzzArray.Length; i++)
            {
                Console.Write(fizzbuzzArray[i] + " ");
            }
            Console.WriteLine("");
            //Starts the FizzBuzz program
            list.FizzBuzz(fizzbuzzArray);
            //Detatches the listener from the program
            listener.Detatch();

            Console.ReadKey();
        }
    }
}
