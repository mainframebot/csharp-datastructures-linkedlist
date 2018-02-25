using NUnit.Framework;
using SinglyLinkedList;

namespace LinkedList.Tests.SinglyLinkedList
{
    public abstract class Base
    {
        #region Setup

        public SinglyLinkedList<string> PopulatedLinkedList { get; set; }

        public SinglyLinkedList<string> SingleItemLinkedList { get; set; }

        public SinglyLinkedList<string> EmptyLinkedList { get; set; }

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
            PopulatedLinkedList = new SinglyLinkedList<string>();
            foreach (var item in Items)
            {
                PopulatedLinkedList.AddLast(item);
            }
        }

        private void GenerateSingleItemExample()
        {
            SingleItemLinkedList = new SinglyLinkedList<string>();
            SingleItemLinkedList.AddLast(Items[0]);
        }

        private void GenerateEmptyExample()
        {
            EmptyLinkedList = new SinglyLinkedList<string>();
        }

        #endregion
    }
}
