using NUnit.Framework;

namespace LinkedList.Tests.DoublyLinkedList
{
    [TestFixture]
    public class Clear : Base
    {
        #region Tests

        // Test: Use Clear() to reset an empty list
        // Outcome:
        // 1. Head should be null
        // 2. Tail should be null
        // 3. Count should equal 0
        [Test]
        public void ClearEmptyList()
        {
            EmptyLinkedList.Clear();

            Assert.That(EmptyLinkedList.Head, Is.Null);
            Assert.That(EmptyLinkedList.Tail, Is.Null);
            Assert.That(EmptyLinkedList.Count, Is.EqualTo(0));
        }

        // Test: Use Clear() to reset a single item list
        // Outcome:
        // 1. Head should be null
        // 2. Tail should be null
        // 3. Count should equal 0
        [Test]
        public void ClearSingleItemList()
        {
            SingleItemLinkedList.Clear();

            Assert.That(SingleItemLinkedList.Head, Is.Null);
            Assert.That(SingleItemLinkedList.Tail, Is.Null);
            Assert.That(SingleItemLinkedList.Count, Is.EqualTo(0));
        }

        // Test: Use Clear() to reset a populated list
        // Outcome:
        // 1. Head should be null
        // 2. Tail should be null
        // 3. Count should equal 0
        [Test]
        public void ClearPopulatedList()
        {
            PopulatedLinkedList.Clear();

            Assert.That(PopulatedLinkedList.Head, Is.Null);
            Assert.That(PopulatedLinkedList.Tail, Is.Null);
            Assert.That(PopulatedLinkedList.Count, Is.EqualTo(0));
        }

        #endregion
    }
}
