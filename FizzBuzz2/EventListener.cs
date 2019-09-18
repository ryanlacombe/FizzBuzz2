using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz2
{
    class EventListener
    {
        private ListWithChangedEvents List;

        public EventListener(ListWithChangedEvents list)
        {
            List = list;
            List.Changed += new ChangeEventHandler(OnListChanged);
        }
        private void OnListChanged(object sender, EventArgs e)
        {
            Console.WriteLine("ListChanged Event recieved.");
        }
        public void Detatch()
        {
            List.Changed -= new ChangeEventHandler(OnListChanged);
            List = null;
        }
    }
}
