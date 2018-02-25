using System;
using System.Collections;
using System.Collections.Generic;
using SinglyLinkedList.Models;

namespace SinglyLinkedList
{
    public class SinglyLinkedList<T> : ICollection<T>
    {
        public Node<T> Head { get; private set; }

        public Node<T> Tail { get; private set; }

        #region Add Operations

        public void AddFirst(T value)
        {
            AddFirst(new Node<T>(value));
        }

        public void AddFirst(Node<T> node)
        {
            Node<T> temp = Head;
            Head = node;
            Head.Next = temp;

            if (Count == 0)
                Tail = node;

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
            }

            Tail = node;
            Count++;
        }

        #endregion

        #region Remove Operations

        public void RemoveFirst()
        {
            if (Count == 0)
                throw new ArgumentOutOfRangeException();
        
            Head = Head.Next;

            if (Count == 1)
                Tail = null;

            Count--;
        }

        public void RemoveLast()
        {
            if (Count == 0)
                throw new ArgumentOutOfRangeException();

            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Node<T> current = Head;

                while (current.Next != Tail)
                    current = current.Next;

                current.Next = null;
                Tail = current;
            }

            Count--;
        }

        #endregion

        #region ICollection<T> Interface Implementaiton

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

        public void Add(T value)
        {
            AddFirst(value);
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T value)
        {
            if (Count != 0)
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
            }

            return false;
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

        public bool Remove(T value)
        {
            if(Count == 0)
                throw new ArgumentOutOfRangeException();

            Node<T> current = Head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previous == null)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            Tail = previous;
                        }

                        Count--;
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public int Count { get; private set; }
        public bool IsReadOnly { get { return false; } }

        #endregion
    }
}
