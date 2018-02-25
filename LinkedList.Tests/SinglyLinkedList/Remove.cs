using System;
using System.Linq;
using NUnit.Framework;
using SinglyLinkedList.Models;

namespace LinkedList.Tests.SinglyLinkedList
{
    [TestFixture]
    public class Remove : Base
    {
        #region Tests

        // Test: Use RemoveFirst() to remove an item from an empty list
        // Outcome:
        // 1. ArgumentOutOfRangeException is thrown
        [Test]
        public void RemoveFirstFromEmptyList()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => EmptyLinkedList.RemoveFirst());
        }

        // Test: Use RemoveFirst() to remove an item from a single item list
        // Outcome:
        // 1. Head should equal null
        // 2. Tail should equal null
        // 3. Count should equal 0
        [Test]
        public void RemoveFirstFromSingleItemList()
        {
            SingleItemLinkedList.RemoveFirst();

            Assert.That(SingleItemLinkedList.Head, Is.Null);
            Assert.That(SingleItemLinkedList.Tail, Is.Null);
            Assert.That(SingleItemLinkedList.Count, Is.EqualTo(0));
        }

        // Test: Use RemoveFirst() to remove an item from a populated list
        // Outcome:
        // 1. Head should equal items[1] "Sorry" (the original head's next item)
        // 2. Tail should remain unchanged
        // 3. Count should equal items - 1
        [Test]
        public void RemoveFirstFromPopulatedList()
        {
            PopulatedLinkedList.RemoveFirst();

            Assert.That(PopulatedLinkedList.Head.Value, Is.EqualTo(Items[1]));
            Assert.That(PopulatedLinkedList.Tail.Value, Is.EqualTo(Items.Last()));
            Assert.That(PopulatedLinkedList.Count, Is.EqualTo(Items.Length - 1));
        }

        // Test: Use RemoveLast() to remove an item from an empty list
        // Outcome:
        // 1. ArgumentOutOfRangeException is thrown
        [Test]
        public void RemoveLastFromEmptyList()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => EmptyLinkedList.RemoveLast());
        }

        // Test: Use RemoveLast() to remove an item from a single item list
        // Outcome:
        // 1. Head should equal null
        // 2. Tail should equal null
        // 3. Count should equal 0
        [Test]
        public void RemoveLastFromSingleItemList()
        {
            SingleItemLinkedList.RemoveLast();

            Assert.That(SingleItemLinkedList.Head, Is.Null);
            Assert.That(SingleItemLinkedList.Tail, Is.Null);
            Assert.That(SingleItemLinkedList.Count, Is.EqualTo(0));
        }

        // Test: Use RemoveLast() to remove an item from a populated list
        // Outcome:
        // 1. Head should remain unchanged
        // 2. Tail should equal items[8] (the original tail's previous item)
        // 3. Count should equal items - 1
        [Test]
        public void RemoveLastFromPopulatedList()
        {
            PopulatedLinkedList.RemoveLast();

            Assert.That(PopulatedLinkedList.Head.Value, Is.EqualTo(Items.First()));
            Assert.That(PopulatedLinkedList.Tail.Value, Is.EqualTo(Items[8]));
            Assert.That(PopulatedLinkedList.Count, Is.EqualTo(Items.Length - 1));
        }

        // Test: Use Remove() to remove an item by value from an empty list
        // Outcome:
        // 1. ArgumentOutOfRangeException is thrown
        [Test]
        public void RemoveFromEmptyList()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => EmptyLinkedList.Remove(Items[0]));
        }

        // Test: Use Remove() to remove an item by value from a single item list
        // Outcome:
        // 1. Head should equal null
        // 2. Tail should equal null
        // 3. Count should equal 0
        [Test]
        public void RemoveFromSingleItemList()
        {
            SingleItemLinkedList.Remove(Items[0]);

            Assert.That(SingleItemLinkedList.Head, Is.Null);
            Assert.That(SingleItemLinkedList.Tail, Is.Null);
            Assert.That(SingleItemLinkedList.Count, Is.EqualTo(0));
        }

        // Test: Use Remove() to remove the first item by value from a populated list
        // Outcome:
        // 1. Return true
        // 2. Head should equal items[1] "Sorry"
        // 3. Tail should remain unchanged
        // 4. Count should equal items - 1
        [Test]
        public void RemoveFromPopulatedListFirstValue()
        {
            Assert.That(PopulatedLinkedList.Remove(Items.First()), Is.True);  
            Assert.That(PopulatedLinkedList.Head.Value, Is.EqualTo(Items[1]));
            Assert.That(PopulatedLinkedList.Tail.Value, Is.EqualTo(Items.Last()));
            Assert.That(PopulatedLinkedList.Count, Is.EqualTo(Items.Length - 1));
        }

        // Test: Use Remove() to remove the middle item [5] "Afraid" by value from a populated list
        // Outcome:
        // 1. Return true
        // 2. Head should remain unchanged
        // 3. Tail should remain unchanged
        // 4. Count should equal items - 1
        // 5. Original items[4] "I'm" next value should equal original items[6] "I"
        [Test]
        public void RemoveFromPopulatedListMiddleValue()
        {
            Assert.That(PopulatedLinkedList.Remove(Items[5]), Is.True);    
            Assert.That(PopulatedLinkedList.Head.Value, Is.EqualTo(Items.First()));
            Assert.That(PopulatedLinkedList.Tail.Value, Is.EqualTo(Items.Last()));
            Assert.That(PopulatedLinkedList.Count, Is.EqualTo(Items.Length - 1));

            Node<string> current = PopulatedLinkedList.Head;
            while (current.Value != Items[4])
            {
                current = current.Next;
            }
               
            Assert.That(current.Next.Value, Is.EqualTo(Items[6]));
        }

        // Test: Use Remove() to remove the end item by value from a populated list
        // Outcome:
        // 1. Return true
        // 2. Head should remain unchanged
        // 3. Tail should equal items[8] "Do" 
        // 4. Count should equal items - 1
        [Test]
        public void RemoveFromPopulatedListEndValue()
        {
            Assert.That(PopulatedLinkedList.Remove(Items.Last()), Is.True);
            Assert.That(PopulatedLinkedList.Head.Value, Is.EqualTo(Items.First()));
            Assert.That(PopulatedLinkedList.Tail.Value, Is.EqualTo(Items[8]));
            Assert.That(PopulatedLinkedList.Count, Is.EqualTo(Items.Length - 1));
        }

        // Test: Use Remove() to remove an item by value from a populated list which does not exist
        // Outcome:
        // 1. Return false
        // 2. Count should remain unchanged
        [Test]
        public void RemoveFromPopulatedListDoesNotExist()
        {
            Assert.That(PopulatedLinkedList.Remove(Item), Is.False);
            Assert.That(PopulatedLinkedList.Count, Is.EqualTo(Items.Length));
        }

        #endregion
    }
}
