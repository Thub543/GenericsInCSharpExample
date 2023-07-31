using System;
using System.Collections.Generic;

namespace NodeApplication;

public class Node<T> where T : IComparable<T>
{
    private readonly T _value;
    private Node<T>? _left;
    private Node<T>? _right;
    
    public Node(T value)
    {
        _value = value;
    }
    
    public void Add(T value) {
        if (value.CompareTo(_value) < 0) {
            if (_left is null)
                _left = new Node<T>(value);
            else
                _left.Add(value);
        }
        else {
            if (_right is null)
                _right = new Node<T>(value);
            else
                _right.Add(value);
        }
    }

    public List<T> ToOrderedList()
    {
        var list = new List<T>();
        TraverseTree(list);
        return list;
    }

    private void TraverseTree(List<T> list)
    {
        if (_left != null)
            _left.TraverseTree(list);
        
        list.Add(_value);
        
        if (_right != null)
            _right.TraverseTree(list);
    }

    public bool Exists(T value)
    {
        if (value.CompareTo(_value) == 0)
            return true;

        if (value.CompareTo(_value) > 0) {

            if (_right is null) 
                return false;
            
            return _right.Exists(value);
        }
        else {
            
            
            if (_left is null)
                return false;
            
            return _left.Exists(value);
        }
    }
}