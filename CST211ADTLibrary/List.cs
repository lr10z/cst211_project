using System;

namespace CST211ADTLibrary
{
    public interface List
    {
        // initial capacity of a list is 10 items (if necessary)
        // index is always 0 (zero) based for all methods

        // get(index) - returns obj at index, or throws exception if out of bounds
        Object get(int index);

        // set(index, entry) - overwrites obj at index and returns the overwritten obj
        Object set(int index, Object anEntry);

        // sizeof() - returns the current number of obj's in the list (NOT the capacity)
        int size();

        // add(entry) - append entry to the end of the list,
        // increment size and then return true;
        // if list has reached current capacity, the capacity is doubled
        bool add(Object anEntry);

        // add(index, entry) - insert entry at index,
        // shift remaining entries to make room and increment size;
        // if list has reached current capacity, the capacity is doubled
        void add(int index, Object anEntry);

        // indexOf(target) - search the list from the beginning for the target obj,
        // returns the index of the matching entry, or returns -1 if not found
        int indexOf(Object target);

        // remove(index) - delete entry at index, returns deleted obj
        Object remove(int index);

        // iterator() - returns new iterator pointing to the first entry in the list
        Iterator iterator();

        // listIterator() - returns new list iterator pointing to the first entry in the list
        ListIterator listIterator();

        // listIterator(index) - returns new list iterator pointing to the entry at index
        ListIterator listIterator(int index);
    }
}
