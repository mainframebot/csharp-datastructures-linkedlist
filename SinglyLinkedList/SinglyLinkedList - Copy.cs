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
            // Compatibility with interface and ease usage of adding a node to the front
            AddFirst(new Node<T>(value));
        }

        // Constant operation (if this was an array all data would need to be shifted to the right, and if the array was full it would require a new resized array to be created and the data copied from the existing array)
        public void AddFirst(Node<T> node)
        {
            // Save the existing Head node, the start of the existing node chain
            Node<T> tempHead = Head;
            // Assign the new node as the Head
            Head = node;
            // Assign the previous Head to be referenced as Next by the new Head node
            Head.Next = tempHead;     
            // If this is the only node in the collection it must also be the Tail node
            if (Count == 0)
            {
                Tail = node;
            }
            // Increment the collection's count
            Count++;
        }

        public void AddLast(T value)
        {
            // Compatibility with interface and ease usage of adding a node to the end
            AddLast(new Node<T>(value));
        }

        public void AddLast(Node<T> node)
        {
            // If the collection is empty the node is added as the Head
            // Else the node is assigned to the Next reference of the Tail node
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }

            // Assign the new node as the Tail
            Tail = node;
            // Increment the collection's count
            Count++;
        }

        #endregion

        #region Remove Operations

        public void RemoveFirst()
        {
            // Assign the reference to the Next node to the Head
            Head = Head.Next;
            // Decrement the collection's count
            Count--;

            // If the collection is empty, set the Tail to null
            if (Count == 0)
            {
                Tail = null;
            }
        }

        public void RemoveLast()
        {
            // Verify if the collection contains any nodes
            if (Count > 0)
            {
                // If there is only one node, remove both the Head and the Tail reference
                // Else if there are more nodes, iterate through the chain until the value for the current node is equal to the Tail node
                // Remove the current nodes Next reference by setting it to null
                // And assign a reference to the current node as the new Tail reference
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Node<T> currentNode = Head;

                    while (currentNode.Next != Tail)
                    {
                        currentNode = currentNode.Next;
                    }

                    currentNode.Next = null;
                    Tail = currentNode;
                }

                // Decrement the collection's count
                Count--;
            }
        }

        #endregion

        #region ICollection Interface Implementations

        public int Count { get; private set; }

        public bool IsReadOnly { get { return false; } }

        public void Add(T value)
        {
            AddFirst(value);
        }

        public bool Remove(T value)
        {
            // Set previous to null (as we have not started traversing the collection)
            // Set current to Head so we can start traversing from the start
            Node<T> previous = null;
            Node<T> current = Head;

            // If collection is empty, the Head will be null and therefore nothing will happen
            while (current != null)
            {
                // Bingo! A match has been found
                if (current.Value.Equals(value))
                {
                    // If the previous is not null, where not dealing the head of the collection
                    // Else we are dealing with the head and we can simply use RemoveFirst
                    if (previous != null)
                    {
                        // Remove reference from current node by breaking the chain and attaching the previous.Next to the current.Next
                        // This will release the current node from the chain
                        previous.Next = current.Next;

                        // If the current node is the Tail of the collection, assign the previous node to the Tail reference
                        if (current.Next == null)
                        {
                            Tail = previous;
                        }

                        // Decrement the collection's count
                        Count--;
                    }
                    else
                    { 
                        RemoveFirst();
                    }

                    // A match has been found, and the node has been removed return true;
                    return true;
                }

                // Assign the current to previous for processing if required in the next cycle through the while loop
                previous = current;
                // Assign the current item's next reference to the current variable, continue looping through the while
                current = current.Next;
            }

            // Value could not be found, therefore couldn't remove node return false;
            return false;
        }

        public bool Contains(T value)
        {
            // Set current to Head so we can start traversing from the start
            Node<T> current = Head;

            // If collection is empty, the Head will be null and therefore nothing will happen
            while (current != null)
            {
                // Bingo! A match has been found
                if (current.Value.Equals(value))
                {
                    // A match has been found, return true;
                    return true;
                }

                // Assign the current item's next reference to the current variable, continue looping through the while
                current = current.Next;
            }

            // Value could not be found, return false
            return false;
        }
        public void Clear()
        {
            // Clear all values, removing references and allowing garbage collector to free up the memory (when it gets there)
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            // Set current to Head so we can start traversing from the start
            Node<T> current = Head;

            // If collection is empty, the Head will be null and therefore nothing will happen
            while (current != null)
            {
                // Determine the index from which to start adding values and store value against index, post-increment index
                array[arrayIndex++] = current.Value;

                // Assign the current item's next reference to the current variable, continue looping through the while
                current = current.Next;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            // Set current to Head so we can start traversing from the start
            Node<T> current = Head;

            // If collection is empty, the Head will be null and therefore nothing will happen
            while (current != null)
            {
                // Yield the current items value back to the calling enumerator
                yield return current.Value;

                // Assign the current item's next reference to the current variable, continue looping through the while
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // Call the generic GetEnumerator, for support of non-generic enumerations
            return GetEnumerator();
        }

        #endregion
    }
}