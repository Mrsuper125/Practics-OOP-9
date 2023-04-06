using System;

namespace Динамический_массив_с_нуля
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
                Append(0);
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
        
        private ListItem GetItem(int index)
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
        
        private void SetItem(int index, int? value)
        {
            int i = index;
            if(index > 0 && index < Length)
            {
                ListItem current = head;
                while (i > 0)
                {
                    current = current.next;
                    i--;
                }

                if (value == null)
                {
                    GetItem(index).next = null;
                }
                else
                {
                    current.value = (int)value;
                        
                }
            }
            else if (index == 0)
            {
                if (value == null)
                {
                    head = null;
                }
                else
                {
                    head.value = (int)value;
                        
                }
            }
            else
            {
                throw new ArgumentException("List index out of range");
            }
        }
        
        public int this[int index]
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

                    return current.value;
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

                    // if (value  == null)
                    // {
                    //     current = null;
                    // }
                    // else
                    // {
                        current.value = value;
                        
                    // }
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
                            SetItem(index-1, null);
                        }
                    }
                    else
                    {
                        SetItem(index, this[index + 1]);
                        GetItem(index).next = GetItem(index+1).next;
                    }
                }
            }
        }
    }

    public class ListItem
    {
        public ListItem next;
        public int value;

        public ListItem(int value, ListItem next)
        {
            this.value = value;
            this.next = next;
        }
    }
}