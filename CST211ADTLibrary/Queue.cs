using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CST211ADTLibrary
{
    public class QueueEmptyException : Exception
    {
        public QueueEmptyException()
            : base("Queue Empty")
        {
        }
    }

    public interface Queue
    {
        // insert() - adds item into the queue and returns item just added
        Object insert(Object item);

        // peek() - returns the item at the front of the queue (i.e. next to be removed);
        // throws QueueEmptyException if the queue is empty
        Object peek();

        // remove() - removes and returns the item at the front of the queue;
        // throws QueueEmptyException if the queue is empty
        Object remove();

        // size() - returns the number of items in the queue
        int size();

        // empty() - returns true if there are no entries in the queue
        bool empty();
    }
}
