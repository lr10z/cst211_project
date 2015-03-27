using System;


namespace CST211ADTLibrary
{
    public class LinkedList : List
    {

        private Node m_head;
        private Node m_tail;
        private int m_size;

        // Ctor
        public LinkedList()
        {
            m_head = null;
            m_tail = null;
            m_size = 0;
        }


        // get(index) - returns obj at index, or throws exception if out of bounds
        public object get(int index)
        {
            Node current = m_head;

            // loop through nodes and stops at index position
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.m_next;
            }

            // returns if obj is found at index position
            if (current.m_data != null)
            {
                return current.m_data;
            }

            throw new Exception("Index is out of bounds!");
        }


        // set(index, entry) - overwrites obj at index and returns the overwritten obj
        public object set(int index, object anEntry)
        {
            Node current = m_head;
           
            int idxFound = 0;

            // loop through nodes and stops at index position
            for (current = m_head; current != null; current = current.m_next)
            {
                // overwrites obj at index
                if (idxFound == index)
                {
                    current.m_data = anEntry;
                    break;
                }

                ++idxFound;
            }

            return current.m_data;
        }


        // sizeof() - returns the current number of obj's in the list (NOT the capacity)
        public int size()
        {
            return m_size;
        }


        // add(entry) - append entry to the end of the list,
        // increment size and then return true;
        // if list has reached current capacity, the capacity is doubled
        public bool add(object anEntry)
        {

            // create new node for anEntry, add to end of the list
            Node n = new Node(anEntry);


            // check if list is empty, adjusts if not empty
            if (m_size == 0)
            {
                m_head = n;
                m_tail = n;
            }
            else
            {
                m_tail.m_next = n;

                n.m_previous = m_tail;

                n.m_next = null;

                m_tail = n;
            }

            m_size++;

            return true;
        }


        // add(index, entry) - insert entry at index,
        // shift remaining entries to make room and increment size;
        // if list has reached current capacity, the capacity is doubled
        public void add(int index, object anEntry)
        {
            Node current;

            // keeps track of current index
            int idxFound = 0;

            // loop through nodes until index is found
            for (current = m_head; current != null; current = current.m_next)
            {
                // if index is found and node is occupied
                if (idxFound == index && current.m_data != null)
                {

                    // if node found is tail node, new node created
                    if (current.m_next == null)
                    {
                        add(current.m_data);
                        break;
                    }

                    // shift remaining entries to make room and increments size
                    else
                    {
                        
                        for (current = m_head; current != null; current = current.m_next)
                        {
                            if (current.m_next == null)
                            {
                                add(current.m_data);
                                break;
                            }
                        }

                        int idx = m_size;

                        for (current = m_tail; current != null; current = current.m_previous)
                        {

                           if( current.m_previous == null )
                           {
                                break;
                           }

                           set(idx-1, current.m_previous.m_data);

                            --idx;
                        }
                        
                        break;
                    }
                }
 
                ++idxFound;
            }

            // insert entry at index
            set(index, anEntry);
        }


        // indexOf(target) - search the list from the beginning for the target obj,
        // returns the index of the matching entry, or returns -1 if not found
        public int indexOf(object target)
        {
            Node current;

            // keeps track of index where target is found
            int idxFound = 0;

            // loop through nodes until target is found
            for ( current = m_head; current != null; current = current.m_next)
            {
                if (current.m_data == target)
                {
                    break;
                }

                idxFound++;

                if (idxFound == m_size && current.m_data != target)
                {
                    return -1;
                }
            }

            // returns index
            return idxFound;
        }


        // remove(index) - delete entry at index, returns deleted obj
        public object remove(int index)
        {
            Node current;

            // keeps track of when index is found
            int idxFound = 0;

            // loop through nodes until index is found
            for (current = m_head; current != null; current = current.m_next)
            {
                // index is found, entry is deleted, and normalizes nodes
                if( idxFound == index )
                {
                    current.m_data = null;
                    --m_size;

                    if (current.m_previous == null && m_size > 0)
                    {
                        current.m_data = current.m_next.m_data;
                        current.m_next = null;
                    }

                    return current;
                }

                idxFound++;

                if (idxFound == m_size && idxFound != index)
                {
                    break;
                }
            }


            throw new Exception("No entry at that index!");
        }


        // iterator() - returns new iterator pointing to the first entry in the list
        public Iterator iterator()
        {
            return new LinkedListIterator(this);
        }


        // listIterator() - returns new list iterator pointing to the first entry in the list
        public ListIterator listIterator()
        {
            return new LinkedListIterator(this);
        }


        // listIterator(index) - returns new list iterator pointing to the entry at index
        public ListIterator listIterator(int index)
        {
            throw new NotImplementedException();
        }


        //
        // Node class
        //
        private class Node
        {
            // Ctor
            public Node( Object data)
            {
                m_data = data;
                m_next = null;
                m_previous = null;
            }

            public Object m_data;
            public Node m_next;
            public Node m_previous;

        }


        //
        // ListIterator Inheritance
        //
        private class LinkedListIterator : ListIterator
        {

            private Node m_current;
            private LinkedList m_list;

            // Ctor
            public LinkedListIterator(LinkedList theList)
            {
                m_list = theList;
                m_current = m_list.m_head;
            }


            // hasNext() - return true if the iterator is pointing to an entry in the list
            // returns false if pointing past the end of the list
            public bool hasNext()
            {
                if (m_current.m_data == null)
                {
                    return false;
                }
               
                return m_current.m_data != null;
            }


            // next() - returns the obj at the current iterator location,
            // and then advances the iterator to point to the next entry
            public object next()
            {
                // finds index
                int iter = m_list.indexOf(m_current.m_data);
                
                if (m_current.m_next == null)
                {
                    m_list.add(null);
                }
                
                // advances iterator
                m_current = m_current.m_next;

                // returns obj at index found
                return m_list.get(iter);
            }


            // remove() - deletes the obj at the current iterator location
            // and leaves the iterator pointing to that location;
            // the underlying list will have shifted the remaining entries down
            public void remove()
            {
                // finds index
                int iter = m_list.indexOf(m_current.m_data);

                // deletes obj at index
                m_list.remove(iter);

                // normalizes nodes
                if (m_current.m_next != null)
                {
                    m_list.add(iter, m_current.m_next.m_data);

                    m_current.m_next = null;
                }

            }
            

            // add(obj) - insert obj at the current location of the iterator,
            // and shift the remaining entries;
            // if iterator is pointing to the entry just beyond the end of the list,
            // then the obj is appended to the list;
            // after adding the object, the iterator continues to point to the same location;
            // if list has reached current capacity, the capacity is doubled
            public void add(object obj)
            {
                if (m_list.m_size == 0)
                {
                    m_list.add(obj);
                    m_current = m_list.m_head;
                }
                else
                {
                    int iter = m_list.indexOf(m_current.m_data);
                    m_list.add(iter, obj);
                }

            }


            // hasPrevious() - returns true if there is an entry before the current
            // location of the iterator, including returning true if iterator points
            // just beyond the last entry in the list
            public bool hasPrevious()
            {
                if (m_current.m_previous != null)
                {
                    return true;
                }

                return false;
            }


            // nextIndex() - returns the index of the current location in the list
            // but does not advance the pointer
            public int nextIndex()
            {
                return  m_list.indexOf(m_current.m_data);
            }


            // previous() - moves the iterator to the previous location in the list,
            //  and returns the object found there
            public object previous()
            {
                m_current = m_current.m_previous;

                return m_list.get(m_list.indexOf(m_current.m_data));
            }


            // previousIndex() - returns the index of the previous location in the list
            // but does not change the pointer
            public int previousIndex()
            {
                if (m_current.m_previous == null)
                {
        
                    return -1;
                }

                return m_list.indexOf(m_current.m_previous.m_data);
            }


            // set(obj) - overwrites the entry pointed to by the iterator with the obj
            public void set(object obj)
            {
                m_list.set(m_list.indexOf(m_current.m_data), obj);
            }


        }

    }
}
