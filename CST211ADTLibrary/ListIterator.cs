using System;


namespace CST211ADTLibrary
{
    public interface ListIterator : Iterator
    {
        // add(obj) - insert obj at the current location of the iterator,
        // and shift the remaining entries;
        // if iterator is pointing to the entry just beyond the end of the list,
        // then the obj is appended to the list;
        // after adding the object, the iterator continues to point to the same location;
        // if list has reached current capacity, the capacity is doubled
        void add(Object obj);

        // hasPrevious() - returns true if there is an entry before the current
        // location of the iterator, including returning true if iterator points
        // just beyond the last entry in the list
        bool hasPrevious();

        // nextIndex() - returns the index of the current location in the list
        // but does not advance the pointer
        int nextIndex();

        // previous() - moves the iterator to the previous location in the list,
        //  and returns the object found there
        Object previous();

        // previousIndex() - returns the index of the previous location in the list
        // but does not change the pointer
        int previousIndex();
        
        // set(obj) - overwrites the entry pointed to by the iterator with the obj
        void set(Object obj);

        // included from Iterator:
        // bool hasNext();
        // Object next();
        // void remove();
    }
}
