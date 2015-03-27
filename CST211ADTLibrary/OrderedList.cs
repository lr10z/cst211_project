using System;

namespace CST211ADTLibrary
{
    public interface OrderedList
    {
        // add() - insert object into the sorted list at the correct location 
        void add(Comparable obj);

        // size() - returns the number of items in the list
        int size();

        // iterator() - returns a new Iterator positioned at the first item in the list
        Iterator iterator();

        // find() - searches for target item in the list and returns an Iterator positioned on that item;
        // if the target is not found, returns null
        Iterator find(Comparable target);
    }
}
