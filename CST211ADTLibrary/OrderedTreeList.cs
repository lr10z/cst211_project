using System;

namespace CST211ADTLibrary
{
    public class OrderedTreeList : OrderedList
    {

        private BinarySearchTree m_tree;

        public OrderedTreeList()
        {
            m_tree = new BinarySearchTree();
        }


        // add() - insert object into the sorted tree at the correct location
        public void add(Comparable obj)
        {  
            m_tree.add(obj);
        }


        // size() - returns the number of Nodes in the tree
        public int size()
        {
            return m_tree.size();
        }


        // iterator() - returns a new Iterator positioned at the first Node in the tree
        public Iterator iterator()
        {
            return m_tree.iterator();
        }


        // find() - searches for target Node in the tree and returns an Iterator positioned on that Node;
        // if the target is not found, returns null
        public Iterator find(Comparable target)
        {
            return (Iterator)m_tree.find(target);
        }




        //
        // Binary Search Tree class
        //
        private class BinarySearchTree : BinaryTree
        {
            
            private int m_size;
            
            // ctor
            public BinarySearchTree()
            {
                m_size = 0;
            }


            // add() - insert object into the sorted tree at the correct location
            public void add(Comparable obj)
            {
                if (m_size == 0)
                {
                    m_root = new Node(obj);
                }
                else
                {
                    add(m_root, obj);
                }
                
                m_size++;
            }

            //
            // object passed-in is compared to object at current Node location
            // then sorted appropriately into tree
            //
            private void add(Node root, Comparable obj)
            {

                // comparable outcomes:
                //
                // -1  if object passed-in < Node at current index position
                //  1  if object passed-in > Node at current index position
                //  0  if object passed-in == Node at current index position
                //
                int compResult = obj.compareTo(root.m_data);

                if (compResult <= 0)
                {
                    if (root.m_left == null)
                    {
                        root.m_left = new Node(obj);
                    }
                    else
                    {
                        add(root.m_left, obj);
                    }
                }
                else
                {
                    if (root.m_right == null)
                    {
                        root.m_right = new Node(obj);
                    }
                    else
                    {
                        add(root.m_right, obj);
                    }
                }

            }


            // size() - returns the number of Nodes in the tree
            public int size()
            {
                return m_size;
            }


            // iterator() - returns a new Iterator positioned at the first Node in the tree
            public Iterator iterator()
            {
                Node leftMost = m_root;

                while (leftMost.m_left != null)
                {
                    leftMost = leftMost.m_left;
                }

                return new TreeIterator( this, leftMost);
            }


            // find() - searches for target Node in the tree and returns an Iterator positioned on that Node;
            // if the target is not found, returns null
            public Iterator find(Comparable target)
            {

                if (m_root == null)
                {
                    return null;
                }


                Node foundIt = null;
                int compResult = target.compareTo(m_root.m_data);

               
                // Value of target is compared with data at root
                if (compResult == 0)
                {
                    foundIt = m_root;
                }
                else if (compResult < 0)
                {
                    foundIt = m_root.m_left;
                }
                else
                {
                    compResult = target.compareTo(m_root.m_right.m_data);

                    if (compResult < 0)
                    {
                        foundIt = m_root.m_right.m_left;
                    }
                    else
                    {
                        foundIt = m_root.m_right;
                    }

                    
                }

                return new TreeIterator(this, foundIt);
            }

            

            //
            // Tree Iterator class
            //
            private class TreeIterator : Iterator
            {

                private BinarySearchTree m_tree;
                private ArrayListStack m_allParents;
                private Node m_current;

                // ctor
                public TreeIterator( BinarySearchTree t, Node current ) 
                {
                    // initialization
                    m_allParents = new ArrayListStack();
                    Node leftMost = t.m_root;

                    m_current = current;
                    
                    m_tree = t;
                }


                // hasNext() - return true if the iterator is pointing to an entry in the tree
                // returns false if pointing past the end of the tree
                public bool hasNext()
                {
                    
                    if( m_current != null )
                    {
                        return true;
                    }
                    
                    return false;
                }


                // next() - returns the obj at the current iterator location,
                // and then advances the iterator to point to the next entry
                // have to do in-order traversal and continue it
                public object next()
                {

                    // current iterator location is stored
                    Node currentIter = m_current;
                    
                    if( m_allParents.empty() )
                    {
          
                        if (m_current.m_right != null)
                        {
                            if (m_current.m_right.m_left != null)
                            {
                                m_allParents.push(m_current.m_right);
                                m_current = m_current.m_right.m_left;
                                return currentIter.m_data;
                            }
                            else
                            {
                                m_allParents.push(m_current);
                                m_current = m_current.m_right;
                                return currentIter.m_data;
                            }
                        }
                        else
                        {
                            m_current = null;
                            return currentIter.m_data;
                        }
                    }
                    

                    Node parent = (Node)m_allParents.peek();

                    //
                    // iterator is advanced to next Node in tree
                    //
                    // if current Node has a child to the right
                    //
                    if (m_current.m_right != null)
                    {

                        m_allParents.push(m_current);


                        // go down to the right
                        m_current = m_current.m_right;

                        // then go all the way to the left
                        // to find leftMost Node
                        Node leftMost = m_current;

                        while (leftMost.m_left != null)
                        {
                            leftMost = leftMost.m_left;
                        }

                        
                        m_current = leftMost;

                    }

                        

                    //  
                    // if current Node is the left child of parent
                    //
                    else if (parent.m_left != null && m_current.m_data == parent.m_left.m_data)
                    {
                       
                        // iterator advances up to parent
                        m_current = parent;

                        // parent is removed from stack
                        m_allParents.pop();

                    }



                    //
                    // if current Node is the right child of parent
                    //
                    else if (parent.m_right != null && m_current.m_data == parent.m_right.m_data)
                    {

                        // iterator advances up until it is the left child of parent
                        while (m_current != parent.m_left)
                        {
                            m_current = (Node)m_allParents.peek();
                            m_allParents.pop();

                            if (m_allParents.empty())
                            {
                                m_current = null;
                                return currentIter.m_data;
                            }

                            parent = (Node)m_allParents.peek();
                        }

                        m_current = (Node)m_allParents.peek();
                        m_allParents.pop();

                    }


                    // current iterator location is returned
                    return currentIter.m_data;
                }


                // remove() - deletes the obj at the current iterator location
                // and leaves the iterator pointing to that location;
                // the underlying tree will have shifted the remaining entries down
                public void remove()
                {
                    throw new NotImplementedException();
                }
            }
             
            
        }

    }
}
