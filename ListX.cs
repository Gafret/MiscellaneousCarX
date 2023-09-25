using System.Collections;
using CarXCodingExercises.Interfaces;

namespace CarXCodingExercises;

public class ListX<T> : IListX<T>, ICollectionX<T>, IEnumerable<T>
    where T: IEquatable<T>
{
    private T[] _elements = new T[4];
    private int _size = 0;
    private int _version = 0;

    public int Count
    {
        get
        {
            return _size;
        }
    }

    public int Capacity
    {
        get
        {
            return _elements.Length;
        }
        set
        {
            int newCapacity = value;
            T[] array = new T[newCapacity];
            Array.Copy(_elements, 0, array, 0, _size);
            _elements = array;
        }
    }

    public ListX()
    {
        
    }

    public ListX(int capacity)
    {
        _elements = new T[capacity];
    }
    
    public T this[int index] {
        get
        {
            if (index >= _size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index gets out of bounds of ListX");
            }
            return _elements[index];
        }
        set
        {
            if (index >= _size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index gets out of bounds of ListX");
            }
            _elements[index] = value;
            _version++;
        }
    }

    public bool Contains(T item)
    {
        foreach (T element in _elements)
        {
            if (element.Equals(item)) return true;
        }

        return false;
    }

    private void ShiftElements(int index)
    {
        // Alternative to Array.Copy()
        int newIndex = 0;
        T[] elementsAfterDeletion = new T[_elements.Length];

        for (int i = 0; i < _size; i++)
        {
            if (i == index)
            {
                continue;
            }
            
            elementsAfterDeletion[newIndex] = _elements[index];
            newIndex++;
        }
        
        _elements = elementsAfterDeletion;
    }

    public bool Remove(T item)
    {
        if (!Contains(item)) return false;

        int deletionIndex = -1;
        
        for (int index = 0; index < _size; index++)
        {
            if (_elements[index].Equals(item))
            {
                deletionIndex = index;
            }

        }

        ShiftElements(deletionIndex);

        _size--;
        _version++;
        return true;
    }

    public int Add(T item)
    {
        if (_size == _elements.Length)
        {
            Capacity = _elements.Length * 2;
        }
        
        _elements[_size] = item;
        _size++;
        _version++;
        return _size - 1;
    }

    public void Clear()
    {
        T[] array = new T[4];
        _elements = array;
        _size = 0;
        _version++;
    }
    
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of bounds of ListX");
        }
        ShiftElements(index);
        _size--;
        _version++;
    }
    
    public int IndexOf(T item)
    {
        for (int index = 0; index < _size; index++)
        {
            if (_elements[index].Equals(item))
            {
                return index;
            }
        }

        return -1;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index >= _size)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of bounds of ListX");
        }
        
        Array.Copy(_elements, index, _elements, index + 1, _size - index);
        _elements[index] = item;
        _version++;
        _size++;
    }
    
    

    public IEnumerator<T> GetEnumerator()
    {
        return (IEnumerator<T>)_elements.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    int IListX.IndexOf(object item)
    {
        return IndexOf((T) item);
    }

    void IListX.Insert(int index, object item)
    {
        Insert(index, (T) item);
    }
    
}