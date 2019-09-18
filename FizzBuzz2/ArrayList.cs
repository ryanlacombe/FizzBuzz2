using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz2
{
    class ArrayList
    {
        protected object[] _arrayList;

        public virtual void Remove(object arrayLists,int index)
        {           
            //Create new array
            object[] newList = new object[_arrayList.Length - 1];
            //put values of old array in new array
            int newPosition = 0;
            for (int i = 0; i < _arrayList.Length; i++)
            {
                if (i != index)
                {
                    newList[newPosition] = _arrayList[i];
                    newPosition++;
                }
            }
            //Set current array to new array
            _arrayList = newList;
        }
        public virtual object this[int index]
        {
            get
            {
                return _arrayList[index];
            }
            set
            {
                _arrayList[index] = value;
            }
        }
        
    }
}
