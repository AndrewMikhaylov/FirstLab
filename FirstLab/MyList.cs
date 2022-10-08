using System;
using System.Collections;
using System.Collections.Generic;

namespace FirstLab
{
    
    public class MyList<T> : IEnumerable<T>
    {
        public delegate void AddDataEventHandler(object source, DataEventArgs<T> args);
        public event AddDataEventHandler DataAdded;
        
        private DoubleNode<T> head;
        private DoubleNode<T> tail;
        private int count;
        
        
        
        public void Add(T data)
        {
            DoubleNode<T> node = new DoubleNode<T>(data);
            
            if (head==null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }

            tail = node;
            count++;
            OnDataAdded(data);
        }

        public void EventHadler(object source, DataEventArgs<T> arg)
        {
            Console.WriteLine("Element " + arg.MyData + " was added");
        }
        protected virtual void OnDataAdded(T data)
        {
            if (DataAdded!=null)
            {
                DataAdded(this, new DataEventArgs<T>(){MyData = data});
            }
        }

        public void AddFirst(T data)
        {
            DoubleNode<T> node = new DoubleNode<T>(data);
            DoubleNode<T> temp = head;

            node.Next = temp;
            head = node;
            if (count == 0)
            {
                tail = head;
            }
            else
            {
                temp.Previous = node;
            }

            count++;
            OnDataAdded(data);
        }
        
        public void AddLast(T data)
        {
            DoubleNode<T> node = new DoubleNode<T>(data);
            DoubleNode<T> temp = tail;

            node.Previous = temp;
            tail = node;
            if (count == 0)
            {
                head=tail;
            }
            else
            {
                temp.Next = node;
            }

            count++;
            OnDataAdded(data);
        }

        public DoubleNode<T> Find(T data)
        {
            DoubleNode<T> current = head;
            while (current!=null)
            {
                if (current.Data.Equals(data))
                {
                    return current;
                }

                current = current.Next;
            }
            return null;
        }

        public void AddBefore(T newElem, DoubleNode<T> existNode)
        {
            if (existNode == null)
            {
                throw new ArgumentNullException();
            }
            DoubleNode<T> node = new DoubleNode<T>(newElem);
            DoubleNode<T> current = head;
            
            while (current!=null)
            {
                if (current.Data.Equals(existNode.Data))
                {
                    break;
                }

                current = current.Next;
            }
            if (current!=null)
            {
                if (current.Previous!=null)
                {
                    node.Next = current;
                    current.Previous.Next = node;
                    node.Previous = current.Previous;
                    current.Previous = node;
                }
                else
                {
                    node.Next = head;
                    head = node;
                }
            }
            count++;
            OnDataAdded(newElem);
        }
        
        public void Remove(T data)
        {
            DoubleNode<T> current = head;

            while (current!=null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }

                current = current.Next;
            }

            if (current!=null)
            {
                if (current.Next!=null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    tail = current.Previous;
                }

                if (current.Previous!=null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }

                count--;
            }
        }
        public int Count => count;
        public bool isEmpty => count == 0;

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        
        public bool Contains(T data)
        {
            DoubleNode<T> current = head;
            while (current!=null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
        }
        
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoubleNode<T> current = head;
            while (current!=null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerable<T> BackEnumerator()
        {
            DoubleNode<T> current = tail;
            while (current!=null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}