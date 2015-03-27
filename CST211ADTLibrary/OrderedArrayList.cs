using System;


namespace CST211ADTLibrary
{
    public class OrderedArrayList : OrderedList
    {
        // member variable
        private ArrayList m_theList;

        // ctor
        public OrderedArrayList()
        {
            m_theList = new ArrayList();
        }


        // add() - insert object into the sorted list at the correct location 
        public void add(Comparable obj)
        {
            
            // insert first item into array
            if (m_theList.size() == 0)
            {
                m_theList.add(obj);
                return;
            }
            

            //
            // object passed-in is compared to object at current index location
            // then sorted appropriately into array
            //
            // comparable outcomes:
            //
            // -1  if object passed-in < item at current index position
            //  1  if object passed-in > item at current index position
            //  0  if object passed-in == item at current index position
            //
            if (obj.compareTo(m_theList.iterator().next()) == -1)
            {
                // smallest object passed-in gets set to the beginning of the array
                m_theList.add(m_theList.indexOf(m_theList.iterator().next()), obj);

            }
            else if (obj.compareTo(m_theList.iterator().next()) == 1)
            {

                int idx = 0;

                //
                // check where in the array, the object passed-in
                // fits best and set it at that specific index
                //
                for (int i = 0; i < m_theList.size(); i++)
                {
                    idx = obj.compareTo(m_theList.get(i));

                    if (idx == -1)
                    {
                        m_theList.add(i, obj);
                        return;
                    }
                }
                
                // largest object passed-in gets set to the end of the array
                m_theList.add(obj);
            }
 
        }


        // size() - returns the number of items in the list
        public int size()
        {
            return m_theList.size();
        }


        // iterator() - returns a new Iterator positioned at the first item in the list
        public Iterator iterator()
        {
            return m_theList.iterator();
        }


        // find() - searches for target item in the list and returns an Iterator positioned on that item;
        // if the target is not found, returns null
        public Iterator find(Comparable target)
        {

            // if array is empty, skip search
            if (m_theList.size() == 0)
            {
                return null;
            }

            // search for target within array
            int found = search(target, 0, m_theList.size());

            if (((Comparable)m_theList.get(found)).compareTo(target) == 0)
            {
                return m_theList.listIterator(found);
            }
            else
            {
                return null;
            }
            
        }


        //
        // search through array to find target
        // when found, index position is returned
        //
        private int search( Comparable target, int lower, int upper)
        {
            
            // base case
            if (upper - lower == 1)
            {
                return lower;
            }
            //recursive case
            else
            {
                int mid = (lower + upper) / 2;

                //
                // check if target is in the upper or lower half of array
                // and only search within appropriate half
                //
                if (target.compareTo(m_theList.get(mid)) == 1)
                {
                    return search(target, mid, upper);
                }
                else if (target.compareTo(m_theList.get(mid)) == -1)
                {
                    return search(target, lower, mid);
                }
                else
                {
                    return mid;
                }
                
            }

        }


    }
}
