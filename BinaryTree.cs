using System;
using System.Collections;
using System.Collections.Generic;

public class BinaryTree<T> : IEnumerable<T> where T : class
{
    private TreeNode<T>? _root;
    private readonly IComparer<T> _comparer;

    public TreeNode<T>? Root => _root;

    public BinaryTree(IComparer<T>? comparer = null)
    {
        _root = null;
        _comparer = comparer ?? Comparer<T>.Default;
    }

    public void Add(T data)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));

        if (_root == null)
        {
            _root = new TreeNode<T>(data);
            return;
        }

        TreeNode<T> current = _root;
        while (true)
        {
            int compareResult = _comparer.Compare(data, current.Data);
            if (compareResult < 0)
            {
                if (current.Left == null)
                {
                    current.Left = new TreeNode<T>(data);
                    break;
                }
                current = current.Left;
            }
            else
            {
                if (current.Right == null)
                {
                    current.Right = new TreeNode<T>(data);
                    break;
                }
                current = current.Right;
            }
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new PreorderIterator(_root);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class PreorderIterator : IEnumerator<T>
    {
        private readonly TreeNode<T>? _rootNode;
        private readonly Stack<TreeNode<T>> _stack;
        private TreeNode<T>? _current;

        public PreorderIterator(TreeNode<T>? root)
        {
            _rootNode = root;
            _stack = new Stack<TreeNode<T>>();
            Reset();
        }

        public T Current => _current != null ? _current.Data : default!;

        object? IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_stack.Count == 0)
            {
                _current = null;
                return false;
            }

            _current = _stack.Pop();

            if (_current.Right != null)
            {
                _stack.Push(_current.Right);
            }
            if (_current.Left != null)
            {
                _stack.Push(_current.Left);
            }

            return true;
        }

        public void Reset()
        {
            _stack.Clear();
            _current = null;
            if (_rootNode != null)
            {
                _stack.Push(_rootNode);
            }
        }

        public void Dispose() { }
    }
}