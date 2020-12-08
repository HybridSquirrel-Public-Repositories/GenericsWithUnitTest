using System;
using System.Collections;
using System.Collections.Generic;

namespace Project_T
{
    public class SingleList<T> : IEnumerable<Node<T>>
    {
    private Node<T> _head;
    private int _count;

        public Node<T> AddFirst(T data)
        {
            var node = new Node<T>(data);
            node.Next = _head;
            _head = node;
            _count++;
            return node;
        }
        public Node<T> AddLast(T data)
        {
            if (_head == null)
            {
                AddFirst(data);
                return null;
            }
            else
            {
                var node = new Node<T>(data);

                Node<T> current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = node;
                _count++;
                return node;
            }
        }
        public void Clear()
        {
            _head = null;
            _count = 0;
        }
        public bool Contains(T data)
        {
            return Find(data) != null;
        }
        public Node<T> Find(T data)
        {
            var comparer = EqualityComparer<T>.Default;
            var current = _head;
            while (current != null)
            {
                if (comparer.Equals(current.Data, data))
                    return current;
                current = current.Next;
            }
            return null;
        }
        public void Remove(Node<T> node)
        {
            var current = _head;

            if (node == null)
                throw new ArgumentNullException();
            else if (current == node)
            {
                _head = _head.Next;
                _count--;
                return;
            }
            while (current != null)
            {
                if (current.Next.Equals(node))
                {
                    current.Next = current.Next.Next;
                    _count--;
                    return;
                }
                current = current.Next;
            }
            throw new InvalidOperationException();
        }
        public bool Remove(T data)
        {
            Node<T> node = Find(data);
            if (node != null)
            {
                Remove(node);
                return true;
            }
            return false;
        }
        public Node<T> Get(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("Index: " + index);

            if (_count == 0)
                return null;

            if (index >= _count)
                index = _count - 1;

            var current = _head;
            for (int i = 0; i < index; i++)
                current = current.Next;
            return current;
        }
    
        public int Count()
        {
            return _count;
        }
    
        public Node<T> this[int index]
        {
            get { return this.Get(index); }
        }
        public void PrintList(SingleList<T> list)
        {
            foreach (var node in list)
            {
                Console.WriteLine(node.Data);
            }
        }
        public IEnumerator<Node<T>> GetEnumerator()
        {
            Node<T> current = _head;
            while(current != null)
            {
                yield return current;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    
    }

}
