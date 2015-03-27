using System;

namespace CST211ADTLibrary
{
    public interface Comparable
    {
        // compareTo() - compares target to this object and returns...
        //     -1  if this is less than target
        //      0  if this is equal to target
        //      1  if this is greater than target
        int compareTo(Object target);
    }
}
