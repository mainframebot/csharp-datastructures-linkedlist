using System.Linq;
using NUnit.Framework;

namespace LinkedList.Tests.DoublyLinkedList
{
    [TestFixture]
    public class Add : Base
    {
        #region Tests

        // Test: Use AddFirst() to add an item to an empty list
        // Outcome:
        // 1. Head should equal added item
        // 2. Tail should equal added item
        // 3. Count should equal 1
        [Test]
        public void AddFirstToEmptyList()
        {
            EmptyLinkedList.AddFirst(Item);

            Assert.That(EmptyLinkedList.Head.Value, Is.EqualTo(Item));
            Assert.That(EmptyLinkedList.Tail.Value, Is.EqualTo(Item));
            Assert.That(EmptyLinkedList.Count, Is.EqualTo(1));
        }

        // Test: Use AddFirst() to add an item to a populated list
        // Outcome:
        // 1. Head should equal added item
        // 2. Tail should remain unchanged
        // 3. Head.Next should equal items[0] (the original head item that was replaced)
        // 4. Count should equal items + 1
        // 5. Head.Next.Previous should equal the added item
        [Test]
        public void AddFirstToPopulatedList()
        {
            PopulatedLinkedList.AddFirst(Item);

            Assert.That(PopulatedLinkedList.Head.Value, Is.EqualTo(Item));
            Assert.That(PopulatedLinkedList.Tail.Value, Is.EqualTo(Items.Last()));
            Assert.That(PopulatedLinkedList.Head.Next.Value, Is.EqualTo(Items.First()));
            Assert.That(PopulatedLinkedList.Count, Is.EqualTo(Items.Length + 1));
            Assert.That(PopulatedLinkedList.Head.Next.Previous.Value, Is.EqualTo(Item));
        }

        // Test: Use AddLast() to add an item to an empty list
        // Outcome:
        // 1. Head should equal added item
        // 2. Tail should equal added item
        // 3. Count should equal 1
        [Test]
        public void AddLastToEmptyList()
        {
            EmptyLinkedList.AddLast(Item);

            Assert.That(EmptyLinkedList.Head.Value, Is.EqualTo(Item));
            Assert.That(EmptyLinkedList.Tail.Value, Is.EqualTo(Item));
            Assert.That(EmptyLinkedList.Count, Is.EqualTo(1));
        }

        // Test: Use AddLast() to add an item to a populated list
        // Outcome:
        // 1. Head should remain unchanged
        // 2. Tail should equal added item
        // 3. Count should equal items + 1
        // 4. Tail.Previous should equal items[9]/Last "That"
        [Test]
        public void AddLastToPopulatedList()
        {
            PopulatedLinkedList.AddLast(Item);

            Assert.That(PopulatedLinkedList.Head.Value, Is.EqualTo(Items.First()));
            Assert.That(PopulatedLinkedList.Tail.Value, Is.EqualTo(Item));
            Assert.That(PopulatedLinkedList.Count, Is.EqualTo(Items.Length + 1));
            Assert.That(PopulatedLinkedList.Tail.Previous.Value, Is.EqualTo(Items.Last()));
        }

        #endregion
    }
}
