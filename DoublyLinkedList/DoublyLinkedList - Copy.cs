using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoublyLinkedList.Models;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        public Node<T> Head { get; set; }

        public Node<T> Tail { get; set; }

        #region Add Operations

        public void AddFirst(T value)
        {
            // Compatibility with interface and ease usage of adding a node to the front
            AddFirst(new Node<T>(value));
        }

        public void AddFirst(Node<T> node)
        {
            // Save the existing Head node
            Node<T> tempHead = Head;
            // Assign the new node as the Head
            Head = node;
            // Assign the previous Head to be referenced as Next by the new Head node
            Head.Next = tempHead;

            // If this is the only node in the collection it must also be the Tail node
            // Else assign the Head reference to the previous Head's Previous
            if (Count == 0)
            {
                Tail = Head;
            }
            else
            {
                tempHead.Previous = Head;
            }

            // Increment the collection's count
            Count++;
        }

        public void AddLast(T value)
        {
            AddLast(new Node<T>(value));
        }

        public void AddLast(Node<T> node)
        {

            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail; 
            }

            Tail = node;
            Count++;
        }

        #endregion

        #region Remove Operations

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                Head = Head.Next;

                Count--;

                if (Count == 0)
                {
                    Tail = null;
                }
                else
                {
                    Head.Previous = null;
                }

            }
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Tail.Previous.Next = null;
                    Tail = Tail.Previous;
                }

                Count--;
            }
        }

        #endregion

        #region ICollection Interface Implementations

        public void Add(T value)
        {
            AddFirst(value);
        }

        public bool Remove(T value)
        {
            Node<T> current = Head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        
                        if (current.Next == null)
                        {
                            Tail = previous;
                        }
                        else
                        {
                            current.Next.Previous = previous;
                        }

                        Count--;
                    }
                    else
                    {
                        RemoveFirst();
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public bool Contains(T value)
        {
            Node<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
 
        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly { get { return false; } }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

    }
}
