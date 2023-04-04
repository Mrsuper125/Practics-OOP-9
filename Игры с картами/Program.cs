using System;

namespace Игры_с_картами
{
    class List
    {
        private ListItem head;

        public List()
        {
            head = null;
        }
        

        public void Append(ListItem item)
        {
            int length = Length();
            if (length == 0)
            {
                head = item;
            }
            else
            {
                ListItem current = head;
                while (length != 0)
                {
                    
                    Console.WriteLine(current.value);
                    current = current.next;
                    length--;
                }

                current.next = item;
            }
        }
        
        public List(int length)
        {
            for (int i = 0; i < length; i++)
            {
                Append(new ListItem(i, null));
            }
        }

        public int Length()
        {
            if (head == null)
            {
                return 0;
            }
            else
            {
                int res = 0;
                ListItem link = head;
                while (link.next != null)
                {
                    link = link.next;
                    res++;
                }

                return res;
            }
        }
        
        public ListItem Get(int index)
        {
            Console.WriteLine(head.next);
            ListItem current = head;
            while (index > 0)
            {
                current = current.next;
                index--;
            }

            return current;
        }
    }

    class ListItem
    {
        public ListItem next;
        public int value;

        public ListItem(int value, ListItem next)
        {
            this.value = value;
            this.next = next;
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            List list = new List(5);
            Console.WriteLine(list.Length());
        }
    }
}