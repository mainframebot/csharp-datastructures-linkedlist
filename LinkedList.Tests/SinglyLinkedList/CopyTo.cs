using System;
using NUnit.Framework;

namespace LinkedList.Tests.SinglyLinkedList
{
    [TestFixture]
    public class CopyTo : Base
    {
        #region Tests

        // Test: Use CopyTo() with an array which is lacks capacity to store list items
        // Outcome:
        // 1. IndexOutOfRangeException is thrown due to array overflow
        [Test]
        public void CopyToOverflowArrayPopulatedList()
        {
            var array = new string[10];

            Assert.Throws<IndexOutOfRangeException>(() => PopulatedLinkedList.CopyTo(array, 5));
        }

        // Test: Use CopyTo() with an array which has sufficient capacity to store list items
        // Outcome:
        // 1. Item in arrayIndex position is equal to list head
        // 2. Item in arrayIndex + list count poisition is equal to list tail
        [Test]
        public void CopyToSuccessPopulatedList()
        {
            var array = new string[15];
            var arrayIndex = 5;

            PopulatedLinkedList.CopyTo(array, arrayIndex);

            Assert.That(array[arrayIndex], Is.EqualTo(PopulatedLinkedList.Head.Value));
            Assert.That(array[arrayIndex + PopulatedLinkedList.Count - 1], Is.EqualTo(PopulatedLinkedList.Tail.Value));
        }

        #endregion
    }
}
