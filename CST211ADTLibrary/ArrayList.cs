using System;


namespace CST211ADTLibrary
{

    //
    // List Inheritance
    //
    public class ArrayList : List
    {
        
        private int m_size;
        private Object [] m_array;


        // Ctor
        public ArrayList()
        {
            m_size = 0;
            m_array = new object[10];
        }


        // get(index) - returns obj at index, or throws exception if out of bounds
        public object get(int index)
        {
            if (m_array[index] != null)
            {
                return m_array[index];
            }

            throw new Exception("Index is out of bounds!");
        }


        // set(index, entry) - overwrites obj at index and returns the overwritten obj
        public object set(int index, object anEntry)
        {
            m_array[index] = anEntry;

            return m_array;
        }


        // sizeof() - returns the current number of obj's in the list (NOT the capacity)
        public int size()
        {
            return m_size;
        }


        // checks if capacity needs adjustment
        public void checkCapacity()
        {
            if (m_size >= m_array.Length)
            {
                Object[] newarray = new Object[m_array.Length * 2];

                Array.Copy(m_array, newarray, m_size);

                m_array = newarray;
            }
        }


        // add(entry) - append entry to the end of the list,
        // increment size and then return true;
        // if list has reached current capacity, the capacity is doubled
        public bool add(object anEntry)
        {
            checkCapacity();
            
            m_array[m_size] = anEntry;
            
            m_size++;

            return true;
        }


        // add(index, entry) - insert entry at index,
        // shift remaining entries to make room and increment size;
        // if list has reached current capacity, the capacity is doubled
        public void add(int index, object anEntry)
        {
            checkCapacity();

            // shift entries to make room for new entry
            for (int i = m_size; i > index; i--)
            {
                m_array[i] = m_array[i - 1];
            }

            set(index, anEntry);

            m_size++;
        }


        // indexOf(target) - search the list from the beginning for the target obj,
        // returns the index of the matching entry, or returns -1 if not found
        public int indexOf(object target)
        {
            int idxFound = Array.IndexOf(m_array, target);

            return idxFound;
        }


        // remove(index) - delete entry at index, returns deleted obj
        public object remove(int index)
        {
            m_array[index] = null;

            --m_size;

            if (m_size == 1 && m_array[0] == null)
            {
                m_array[0] = m_array[1];
         
                m_array[1] = null;
            }

            return m_array;
        }


        // iterator() - returns new iterator pointing to the first entry in the list
        public Iterator iterator()
        {
            return new ArrayIterator(this);
        }


        // listIterator() - returns new list iterator pointing to the first entry in the list
        public ListIterator listIterator()
        {
            return new ArrayIterator(this);
        }

        
        // listIterator(index) - returns new list iterator pointing to the entry at index
        public ListIterator listIterator(int index)
        {
            return new ArrayIterator(this, index);
        }
        

        //
        // ListIterator Inheritance
        //
        private class ArrayIterator : ListIterator
        {
            
            private int m_current;
            private ArrayList m_list;


            // Ctor
            public ArrayIterator( ArrayList theList ) //needs to know what iterator to point to, therefore we pass-in ArrayList Object
            {
                m_list = theList;
                m_current = 0;
            }

            public ArrayIterator( ArrayList theList, int index) 
            {
                m_list = theList;
                m_current = index;
            }


            // hasNext() - return true if the iterator is pointing to an entry in the list
            // returns false if pointing past the end of the list
            public bool hasNext()
            {
                return m_current < m_list.size();
            }


            // next() - returns the obj at the current iterator location,
            // and then advances the iterator to point to the next entry
            public object next()
            {
                return m_list.get(m_current++);
            }


            // remove() - deletes the obj at the current iterator location
            // and leaves the iterator pointing to that location;
            // the underlying list will have shifted the remaining entries down
            public void remove()
            {
                m_list.remove(m_current);

                if (hasNext() == true && m_list.size() == 1)
                {
                    return;
                }
                else if ( hasNext() == true )
                {

                    for (int i = m_current; i < m_list.size(); i++)
                    {
                        m_list.set( i, m_list.get( i + 1));
                    }

                    m_list.set( m_list.size(), null);
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
                m_list.add( m_current, obj);
            }


            // hasPrevious() - returns true if there is an entry before the current
            // location of the iterator, including returning true if iterator points
            // just beyond the last entry in the list
            public bool hasPrevious()
            {
                if (m_current > 0)
                {
                    return true;
                }

                return false;
            }


            // nextIndex() - returns the index of the current location in the list
            // but does not advance the pointer
            public int nextIndex()
            {
                return m_current;
            }


            // previous() - moves the iterator to the previous location in the list,
            //  and returns the object found there
            public object previous()
            {
                return m_list.get(--m_current);
            }


            // previousIndex() - returns the index of the previous location in the list
            // but does not change the pointer
            public int previousIndex()
            {
                return (m_current - 1);
            }


            // set(obj) - overwrites the entry pointed to by the iterator with the obj
            public void set(object obj)
            {
                m_list.set(m_current, obj);
            }
        }
    }
}
