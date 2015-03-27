using System;

namespace CST211ADTLibrary
{
    public class CircularArrayQueue : Queue
    {

        //
        // member variable
        //
        private int m_inQ;
        private int m_head;
        private int m_tail;
        private object [] m_array;
        

        //
        // ctor
        //
        public CircularArrayQueue()
        {
            m_inQ = 0;
            m_array = new object[10];
            m_head = 0;
            m_tail = 0;
        }


        // checks if capacity needs adjustment
        public void checkCapacity()
        {
            if (m_inQ >= m_array.Length)
            {

                Object [] newarray = new Object[m_array.Length * 2];
                
                int n = 0;

                for( int i = m_head; i < m_array.Length; i++, n++)
                {
                    newarray[n] = m_array[i];
                }
                for (int i = 0; i < m_tail; i++)
                {
                    newarray[n] = m_array[i];
                }
                

               m_array = newarray;

               m_head = 0;
               m_tail = m_inQ;

            }
        }


        // insert() - adds item into the queue and returns item just added
        public object insert(object item)
        {
            checkCapacity();

            if (m_tail == m_array.Length)
            {
                m_tail = 0;
            }

            m_array[m_tail] = item;
            
            m_inQ++;
            m_tail++;

            return m_array;
        }


        // peek() - returns the item at the front of the queue (i.e. next to be removed);
        // throws QueueEmptyException if the queue is empty
        public object peek()
        {
            if (empty()){throw new QueueEmptyException();}

            return m_array[m_head];
        }


        // remove() - removes and returns the item at the front of the queue;
        // throws QueueEmptyException if the queue is empty
        public object remove()
        {
            if (empty()) { throw new QueueEmptyException(); }

            if (m_head == m_array.Length)
            {
                m_head = 0;
            }

            object qFront = m_array[m_head];

            m_array[m_head] = null;

            --m_inQ;

            if (!empty())
            {
                m_head++;
            }
            else
            {
                --m_tail;
            }

            return qFront;
        }


        // size() - returns the number of items in the queue
        public int size()
        {
            return m_inQ;
        }


        // empty() - returns true if there are no entries in the queue
        public bool empty()
        {
            if (size() == 0)
            {
                return true;
            }

            return false;
        }
    }
}
