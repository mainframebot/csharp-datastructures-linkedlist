using NUnit.Framework;

namespace LinkedList.Tests.SinglyLinkedList
{
    [TestFixture]
    public class Contains : Base
    {
        #region Tests

        // Test: Use Contains() to determine if an empty list has a value
        // Outcome:
        // 1. List does not contain item (false)
        [Test]
        public void Contains_EmptyList()
        {
            Assert.That(EmptyLinkedList.Contains(Item), Is.False);
        }

        // Test: Use Contains() to determine if a populated list contains a value (true)
        // Outcome:
        // 1. List does contain item (true)
        [Test]
        public void ContainsMatchPopulatedList()
        {
            Assert.That(PopulatedLinkedList.Contains(Items[5]), Is.True);
        }

        // Test: Use Contains() to determine if a populated list contains a value (false)
        // Outcome:
        // 1. List does note contain item (false)
        [Test]
        public void ContainsNoMatchPopulatedList()
        {
            Assert.That(PopulatedLinkedList.Contains(Item), Is.False);
        }

        #endregion
    }
}
