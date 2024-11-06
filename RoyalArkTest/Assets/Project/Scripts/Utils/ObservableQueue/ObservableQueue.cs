using System;
using System.Collections.Generic;

namespace RoyalArkTest.Utils.ObservableQueue
{
    public class ObservableQueue<T>
    {
        public Action ItemWasAdded;
        public Action ItemWasRemoved;

        private Queue<T> queue = new Queue<T>();

        public void Enqueue(T item)
        {
            queue.Enqueue(item);
            ItemWasAdded?.Invoke();
        }

        public T Dequeue()
        {
            ItemWasRemoved?.Invoke();
            return queue.Dequeue();
        }

        public T Peek() => queue.Peek();

        public int Count => queue.Count;
    }
}