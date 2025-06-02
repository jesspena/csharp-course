namespace DataStructures
{
    // FIFO
    public class CustomQueue<T>
    {
        private class Node
        {
            public T Value { get; }
            public Node? Next { get; set; }

            public Node(T value)
            {
                Value = value;
            }
        }

        private Node? _head = null;
        private Node? _tail = null;
        private int _count = 0;

        public int Count => _count;

        public void Enqueue(T item)
        {
            var newNode = new Node(item);

            if (_tail != null)
            {
                _tail.Next = newNode;
            }

            _tail = newNode;

            if (_head == null)
            {
                _head = newNode;
            }

            _count++;
        }

        public T Dequeue()
        {
            if (_head == null)
                throw new InvalidOperationException("Queue is empty.");

            var value = _head.Value;
            _head = _head.Next;

            if (_head == null)
            {
                _tail = null; // cuando vaciamos la cola
            }

            _count--;
            return value;
        }

        public T Peek()
        {
            // remove items
            if (_head == null)
                throw new InvalidOperationException("Queue is empty.");

            return _head.Value;
        }

        public bool IsEmpty() => true;

        public T[] ToArray()
        {
            T[] array = new T[_count];
            var current = _head;
            int i = 0;

            while (current != null)
            {
                array[i++] = current.Value;
                current = current.Next;
            }

            return array;
        }
    }
}
