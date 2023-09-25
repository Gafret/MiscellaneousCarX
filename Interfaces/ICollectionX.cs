namespace CarXCodingExercises.Interfaces;


public interface ICollectionX<T> 
{
    public int Count { get; }

    public int Add(T item);
    public void Clear();
    public bool Contains(T item);
    public bool Remove(T item);
}