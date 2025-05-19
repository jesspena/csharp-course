namespace Test.DataStructures
{
    public class TestDoublyLinkedList
    {
        [Fact]
        public void AddFirst_ShouldInsertAtFront()
        {
            var list = new DoublyLinkedList<string>();
            list.AddFirst("Carlos");
            list.AddFirst("Sergio");
            list.AddFirst("Fabricio");

            var result = list.Get(0);

            Assert.Equal("Fabricio", result);
        }

        [Fact]
        public void AddLast_ShouldInsertAtEnd()
        {
            var list = new DoublyLinkedList<string>();
            list.AddLast("Carlos");
            list.AddLast("Sergio");
            list.AddLast("Fabricio");

            var result = list.Get(2);

            Assert.Equal("Fabricio", result);
        }

        [Fact]
        public void ToReversedArray_ShouldReturnCorrectReverseOrder()
        {
            // TODO: Complete the test
            var list = new DoublyLinkedList<int>();
            list.AddLast(3);
            list.AddLast(2);
            list.AddLast(1);

            
            Assert.Equal(new[] {1, 2, 3}, list.ToReversedArray());
        }

        [Fact]
        public void Get_ShouldReturnCorrectElement()
        {
            // TODO: Complete the test
            var list = new DoublyLinkedList<char>();
            list.AddLast('A');
            list.AddLast('B');
            list.AddLast('C');

            Assert.Equal('A', list.Get(0));
            Assert.Equal('B', list.Get(1));
            Assert.Equal('C', list.Get(2));
        }

        [Fact]
        public void Get_ShouldThrow_WhenIndexInvalid()
        {
            // TODO: Complete test
            var list = new DoublyLinkedList<int>();
            list.AddLast(10); //no tengo este indice
            
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(-1));
        }

        [Fact]
        public void Contains_ShouldReturnTrueIfValueExists()
        {
            // TODO: Complete test
            var list = new DoublyLinkedList<string>();
            list.AddLast("Carlos");

            Assert.True(list.Contains("Carlos"));
        }

        [Fact]
        public void Remove_ShouldRemoveExistingValue()
        {
            // TODO: Complete test

            var list = new DoublyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            var result = list.TryRemove(2);

            Assert.True(result);
            Assert.Equal(2, list.Count());
            Assert.Equal(new[] { 1, 3 }, list.ToArray());
        }

        [Fact]
        public void Remove_ShouldReturnFalseIfNotFound()
        {
            // TODO: Complete test

            // Assert.False(result);
            // Assert.Equal(3, list.Count);
            // Assert.Equal(new[] { 1, 2, 3 }, list.ToArray());
        }

        // OPTIONAL: Add more tests if wanted
    }
}
