using NUnit.Framework;
using DoublyLinkedList;

namespace LinkedList.Tests.DoublyLinkedList
{
    public abstract class Base
    {
        #region Setup

        public DoublyLinkedList<string> PopulatedLinkedList { get; set; }

        public DoublyLinkedList<string> SingleItemLinkedList { get; set; }

        public DoublyLinkedList<string> EmptyLinkedList { get; set; }

        public string[] Items = { "I am", "Sorry", "Dave", ",", "I'm", "Afraid", "I", "Can't", "Do", "That" };

        public string Item = "Robot";

        [SetUp]
        public void BeforeEachTest()
        {
            GeneratePopulatedExample();
            GenerateSingleItemExample();
            GenerateEmptyExample();
        }

        #endregion

        #region Private Methods

        private void GeneratePopulatedExample()
        {
            PopulatedLinkedList = new DoublyLinkedList<string>();
            foreach (var item in Items)
            {
                PopulatedLinkedList.AddLast(item);
            }
        }

        private void GenerateSingleItemExample()
        {
            SingleItemLinkedList = new DoublyLinkedList<string>();
            SingleItemLinkedList.AddLast(Items[0]);
        }

        private void GenerateEmptyExample()
        {
            EmptyLinkedList = new DoublyLinkedList<string>();
        }

        #endregion
    }
}
