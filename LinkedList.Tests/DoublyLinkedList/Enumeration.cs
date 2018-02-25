using NUnit.Framework;

namespace LinkedList.Tests.DoublyLinkedList
{
    [TestFixture]
    public class Enumeration : Base
    {
        #region Tests

        // Test: Use enumeration to traverse list
        // Outcome:
        // 1. Counter is equel to list count
        [Test]
        public void EnumeratePopulatedList()
        {
            int counter = 0;
            foreach (var node in PopulatedLinkedList)
            {
                counter++;
            }

            Assert.That(PopulatedLinkedList.Count, Is.EqualTo(counter));
        }

        #endregion
    }
}
