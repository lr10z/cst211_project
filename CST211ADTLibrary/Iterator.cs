using System;

namespace CST211ADTLibrary
{
    public interface Iterator
    {
        // hasNext() - return true if the iterator is pointing to an entry in the list
        // returns false if pointing past the end of the list
        bool hasNext();

        // next() - returns the obj at the current iterator location,
        // and then advances the iterator to point to the next entry
        Object next(); // have to do in-order traversal and continue it

        // remove() - deletes the obj at the current iterator location
        // and leaves the iterator pointing to that location;
        // the underlying list will have shifted the remaining entries down
        void remove(); //
    }
}
