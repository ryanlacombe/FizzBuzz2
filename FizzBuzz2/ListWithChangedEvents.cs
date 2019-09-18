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
        public override void Clear()
        {
            base.Clear();
            OnChanged(EventArgs.Empty);
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

            for (int o = 0; o < arrayLists.Length; o++)
            {
                arrayLists = _arrayList;
                if ((int)arrayLists[o] % 3 == 0 || (int)arrayLists[o] % 5 == 0)
                {
                    if ((int)arrayLists[o] % 3 == 0 && (int)arrayLists[o] % 5 == 0)
                    {
                        Console.Write(arrayLists[o] + " ");
                        BuzzFizz();
                        for (int i = 0; i < arrayLists.Length; i++)
                        {
                            Console.Write(arrayLists[i] + " ");
                        }
                        Console.WriteLine("");
                    }
                    else if ((int)arrayLists[o] % 3 == 0)
                    {
                        Console.Write(arrayLists[o] + " ");
                        Fizz();
                        for (int i = 0; i < arrayLists.Length; i++)
                        {
                            Console.Write(arrayLists[i] + " ");
                        }
                        Console.WriteLine("");
                    }
                    else if ((int)arrayLists[o] % 5 == 0)
                    {
                        Console.Write(arrayLists[o] + " ");
                        Buzz();
                        for (int i = 0; i < arrayLists.Length; i++)
                        {
                            Console.Write(arrayLists[i] + " ");
                        }
                        Console.WriteLine("");
                    }
                }
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
