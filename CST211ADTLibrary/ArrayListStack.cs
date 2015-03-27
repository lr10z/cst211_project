using System;


namespace CST211ADTLibrary
{
    public class ArrayListStack : Stack
    {
        //
        // member variable
        //
        private ArrayList m_myStack;


        //
        // ctor
        //
        public ArrayListStack()
        {
            m_myStack = new ArrayList();
        }


        //
        // empty() - returns true if there are no entries in the stack
        //
        public bool empty()
        {
            if (m_myStack.size() == 0)
            {
                return true;
            }

            return false;
        }


        //
        // peek() - returns the obj at the top of the stack,
        // without removing the object from the stack;
        // throws StackEmptyException if nothing on the stack
        //
        public object peek()
        {
            if (empty() ==  true)
            {
                throw new StackEmptyException();
            }

            return m_myStack.get(m_myStack.size() - 1);
        }


        //
        // pop() - removes the top object from the stack and returns it;
        // throws StackEmptyException if nothing on the stack
        //
        public object pop()
        {
            if (empty() == true)
            {
                throw new StackEmptyException();
            }

            object topOFstack = peek();

            m_myStack.remove(m_myStack.size() - 1);

            return topOFstack;
        }


        //
        // push(obj) - pushes obj onto the stack, making it the top item,
        // returns the object just pushed onto the stack
        //
        public object push(object item)
        {
            return m_myStack.add(item);
        }

    }
}
