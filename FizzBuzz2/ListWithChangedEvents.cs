using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz2
{
    public delegate void ChangeEventHandler(object sender, EventArgs e);

    class ListWithChangedEvents: ArrayList
    {
        public ChangeEventHandler Changed;

        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }
        public override void Remove(object arrayLists, int index)
        {           
            base.Remove(arrayLists, index);           
        }     
        public override object this[int index]
        {
            get
            {
                return _arrayList;
            }
            set
            {              
                _arrayList[index] = value;                
            }
        }
        static void Buzz()
        {
            Console.WriteLine("Buzz.");
        }
        static void Fizz()
        {
            Console.WriteLine("Fizz.");
        }
        static void BuzzFizz()
        {
            Console.WriteLine("FizzBuzz.");
        }
        public void FizzBuzz(object[] arrayLists)
        {
            _arrayList = arrayLists;            

            //Starts the loop to check if the number can by divded by 3 or 5
            for (int o = 0; o < arrayLists.Length; o++)
            {
                arrayLists = _arrayList;
                //Checks if number can be divided by 3 or 5
                if ((int)arrayLists[o] % 3 == 0 || (int)arrayLists[o] % 5 == 0)
                {
                    //Checks if number can be divded by both 3 and 5
                    if ((int)arrayLists[o] % 3 == 0 && (int)arrayLists[o] % 5 == 0)
                    {
                        Console.Write(arrayLists[o] + " ");
                        BuzzFizz();
                        //Prints the current array
                        for (int i = 0; i < arrayLists.Length; i++)
                        {
                            Console.Write(arrayLists[i] + " ");
                        }
                        Console.WriteLine("");
                    }
                    //If can't be divded by both, checks if can be divided by 3
                    else if ((int)arrayLists[o] % 3 == 0)
                    {
                        Console.Write(arrayLists[o] + " ");
                        Fizz();
                        //Prints the current array
                        for (int i = 0; i < arrayLists.Length; i++)
                        {
                            Console.Write(arrayLists[i] + " ");
                        }
                        Console.WriteLine("");
                    }
                    //If can't be divded by both, checks if can be divided by 3
                    else if ((int)arrayLists[o] % 5 == 0)
                    {
                        Console.Write(arrayLists[o] + " ");
                        Buzz();
                        //Prints the current array
                        for (int i = 0; i < arrayLists.Length; i++)
                        {
                            Console.Write(arrayLists[i] + " ");
                        }
                        Console.WriteLine("");
                    }
                }
                //If the number can't be divded by 3 or 5 removes it and sends an event
                else if ((int)arrayLists[o] % 3 != 0 || (int)this[o] % 5 != 0)
                {
                    Remove(arrayLists, o);
                    OnChanged(EventArgs.Empty);
                    o--;
                }
            }
        }
    }
}
