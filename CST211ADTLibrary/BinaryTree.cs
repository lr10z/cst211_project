using System;

namespace CST211ADTLibrary
{
    public class BinaryTree
    {
        protected class Node
        {
            public Object m_data;
            public Node m_left;
            public Node m_right;

            public Node(Object data)
            {
                m_data = data;
                m_left = null;
                m_right = null;
            }
        }

        // m_root - the root node of this binary tree
        protected Node m_root;


        // ctor 1
        // BinaryTree() - constructs empty tree
        public BinaryTree()
        {
            m_root = null;
        }


        // ctor 2
        // BinaryTree(Object, BinaryTree, BinaryTree) - constructs tree with data and left/right sub-trees
        // leftTree and/or rightTree may be null
        public BinaryTree(Object data, BinaryTree leftTree, BinaryTree rightTree)
        {
            m_root = new Node(data);
            m_root.m_left = leftTree.m_root;
            m_root.m_right = rightTree.m_root;
        }


        // ctor 3 protected
        protected BinaryTree(Node root)
        {
            m_root = root;
        }


        // getData() - returns data associated with the root of this tree
        public Object getData()
        {
            return m_root.m_data;
        }


        // isLeaf() - returns true if this tree has no children or false if the tree has 1 or 2 children
        public bool isLeaf()
        {
            if (getLeftSubtree() == null && getRightSubtree() == null)
            {
                return true;
            }

            return false;
        }


        // getLeftSubtree() - returns left sub-tree or null
        public BinaryTree getLeftSubtree()
        {
            if (m_root.m_left == null)
            {
                return null;
            }

            return new BinaryTree(m_root.m_left);
        }


        // getRightSubtree() - returns right sub-tree or null
        public BinaryTree getRightSubtree()
        {
            if (m_root.m_right == null)
            {
                return null;
            }

            return new BinaryTree(m_root.m_right);
        }
    }
}
