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

        public void Append(int value)
        {
            if (head == null)
            {
                head = new ListItem(value, null);
            }
            else
            {
                ListItem current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = new ListItem(value, null);
            }
        }
        
        public List(int length)
        {
            for (int i = 0; i < length; i++)
            {
                Append(i);
            }
        }

        public int Length
        {
            get
            {
                if (head == null)
                {
                    return 0;
                }
                else
                {
                    int res = 1;
                    ListItem link = head;
                    while (link.next != null)
                    {

                        link = link.next;
                        res++;
                    }

                    return res;
                }
            }
        }
        
        public ListItem this[int index]
        {
            get
            {
                if(index >= 0 && index < Length)
                {
                    ListItem current = head;
                    while (index > 0)
                    {
                        current = current.next;
                        index--;
                    }

                    return current;
                }
                else
                {
                    throw new ArgumentException("List index out of range");
                }
            }
            set
            {
                if(index >= 0 && index < Length)
                {
                    ListItem current = head;
                    while (index > 0)
                    {
                        current = current.next;
                        index--;
                    }

                    if (value  == null)
                    {
                        current = null;
                    }
                    else
                    {
                        current = new ListItem(value.value, current.next);
                        
                    }
                }
                else
                {
                    throw new ArgumentException("List index out of range");
                }
            }
        }

        public void Pop(int index)
        {
            if (Length == 0)
            {
                throw new ArgumentException("Can't pop items from an empty List");
            }
            else
            {
                if (index >= Length || index < 0)
                {
                    throw new ArgumentException("List index out of range");
                }
                else
                {
                    if (Length  == index + 1)
                    {
                        if (index == 0)
                        {
                            this.head = null;
                        }
                        else
                        {
                            this[index - 1].next = null;
                        }
                    }
                    else
                    {
                        this[index].value = this[index + 1].value;
                        this[index].next = this[index + 1].next;
                    }
                }
            }
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
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i].value);
            }
            Console.WriteLine(list.Length);
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i].value);
            }
        }
    }
}