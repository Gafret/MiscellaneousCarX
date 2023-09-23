namespace CarXCodingExercises.Interfaces;

public interface IListX : ICollectionX
{
    public int IndexOf(object item);
    public void Insert(int index, object item);
    public void RemoveAt(int index);
}

public interface IListX<T> : IListX, ICollectionX<T>
{
    public int IndexOf(T item);
    public void Insert(int index, T item);
}