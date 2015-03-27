using System;


namespace CST211ADTLibrary
{
    public class StackEmptyException : Exception
    {
        public StackEmptyException()
            : base("Stack Empty")
        {
        }
    }

    public interface Stack
    {
        // empty() - returns true if there are no entries in the stack
        bool empty();

        // peek() - returns the obj at the top of the stack,
        // without removing the object from the stack;
        // throws StackEmptyException if nothing on the stack
        Object peek();

        // pop() - removes the top object from the stack and returns it;
        // throws StackEmptyException if nothing on the stack
        Object pop();

        // push(obj) - pushes obj onto the stack, making it the top item,
        // returns the object just pushed onto the stack
        Object push(Object item);
    }
}
