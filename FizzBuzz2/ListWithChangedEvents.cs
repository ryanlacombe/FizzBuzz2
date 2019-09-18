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
        public override void Remove(int index)
        {           
            base.Remove(index);           
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
                base[index] = value;
                OnChanged(EventArgs.Empty);
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
                    }
                    else if ((int)arrayLists[o] % 3 == 0)
                    {
                        Console.Write(arrayLists[o] + " ");
                        Fizz();
                    }
                    else if ((int)arrayLists[o] % 5 == 0)
                    {
                        Console.Write(arrayLists[o] + " ");
                        Buzz();
                    }
                }
                else if ((int)arrayLists[o] % 3 != 0 || (int)this[o] % 5 != 0)
                {
                    Remove(index);
                    OnChanged(EventArgs.Empty);
                }
            }
        }
    }
}
