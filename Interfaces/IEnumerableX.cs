using System.Collections;

namespace CarXCodingExercises.Interfaces;

public interface IEnumerableX : IEnumerator
{
    public IEnumerator GetEnumerator ();
}

public interface IEnumerableX<out T> : IEnumerableX
{
    public new IEnumerator<T> GetEnumerator();
}