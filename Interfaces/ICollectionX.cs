namespace CarXCodingExercises.Interfaces;

public interface ICollectionX : IEnumerableX
{
    public void CopyTo(Array array, int arrayIndex);
}

public interface ICollectionX<T> : ICollectionX, IEnumerableX<T>
{
    public int Count { get; }
    public bool IsReadOnly { get; }
    
    public int Add(T item);
    public void Clear();
    public bool Contains(T item);
    public void CopyTo(T[] array, int arrayIndex);
    public void Remove(T item);
}