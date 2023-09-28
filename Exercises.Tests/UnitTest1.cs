using System.Runtime.CompilerServices;
using CarXCodingExercises;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;

namespace Exercises.Tests;

public class LinkedListXManipulationTests
{
    private static LinkedListX<int> InitializeIntLinkedList()
    {
        LinkedListX<int> list = new LinkedListX<int>();
        return list;
    }

    private static int[] IntLinkesListToArray(LinkedListX<int> list)
    {
        int[] array = new int[list.Count];
        for (int i = 0; i < list.Count; i++)
        {
            array[i] = list[i];
        }

        return array;
    }
    
    [Fact]
    public void Add_InputNumber_ReturnsTrue()
    {
        var list = InitializeIntLinkedList();
        
        list.Add(1);
        
        Assert.Equal(1, list[0]);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(4, 4)]
    public void Count_FromZeroToSeveralElements_ReturnsTrue(int elementCount, int expectedCount)
    {
        var list = InitializeIntLinkedList();
        for (int i = 0; i < elementCount; i++)
        {
            list.Add(1);
        }
        
        Assert.Equal(expectedCount, list.Count);
    }

    [Fact]
    public void IndexerGetter_SequenceOfElements_ReturnsTrue()
    {
        int[] elements = new int[] { 1, 2, 3, 4, 5, 6 };
        var list = InitializeIntLinkedList();
        foreach (var element in elements)
        {
            list.Add(element);
        }

        for (int i = 0; i < elements.Length; i++)
        {
            Assert.Equal(list[i], elements[i]);
        }
    }
    
    [Fact]
    public void IndexerSetter_SequenceOfElements_ReturnsTrue()
    {
        int[] elements = new int[] { 1, 2, 3, 4, 5, 6 };
        var list = InitializeIntLinkedList();
        for (int i = 0; i < elements.Length; i++)
        {
            list.Add(1);
            list[i] = elements[i];
        }

        for (int i = 0; i < elements.Length; i++)
        {
            Assert.Equal(list[i], elements[i]);
        }
    }
    
    [Fact]
    public void Indexer_ElementOutOfRange_ThrowsException()
    {
        var list = InitializeIntLinkedList();
        list.Add(1);
        Assert.Throws<IndexOutOfRangeException>(() => list[20]);
    }

    [Theory]
    [InlineData(new int[]{1}, new int[]{}, 0)]
    [InlineData(new int[]{1,2,3}, new int[]{1,3}, 1)]
    [InlineData(new int[]{1,2,3}, new int[]{1,2}, 2)]
    [InlineData(new int[]{1,2,3}, new int[]{2, 3}, 0)]
    public void RemoveAt_ItemAtEndsAndMiddle_ReturnsTrue(int[] items, int[] afterDeletion, int index)
    {
        var list = InitializeIntLinkedList();
        
        foreach (var element in items)
        {
            list.Add(element);
        }
        
        list.RemoveAt(index);
        bool result = Enumerable.SequenceEqual(IntLinkesListToArray(list), afterDeletion);
        Assert.True(result);
    }

    [Fact]
    public void RemoveAt_IndexOutOfRange_ThrowsException()
    {
        var list = InitializeIntLinkedList();
        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(2));
    }

    [Fact]
    public void Remove_NoDuplicateElements_ReturnsTrue()
    {
        var list = InitializeIntLinkedList();
        list.Add(1);
        list.Remove(1);
        
        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void Remove_DuplicateElements_ReturnsTrue()
    {
        var list = InitializeIntLinkedList();
        list.Add(1);
        list.Add(1);
        list.Remove(1);
        
        Assert.Equal(1, list.Count);
        Assert.True(list.Contains(1));
    }

    [Fact]
    public void Remove_NoSuchElement_ReturnFalse()
    {
        var list = InitializeIntLinkedList();
        Assert.False(list.Remove(5));
    }

    [Fact]
    public void IndexOf_ElementExists_ReturnTrue()
    {
        var list = InitializeIntLinkedList();
        list.Add(1);
        
        Assert.Equal(0, list.IndexOf(1));
    }

    [Fact]
    public void IndexOf_ElementDoesntExist_ReturnsFalse()
    {
        var list = InitializeIntLinkedList();
        
        Assert.Equal(-1, list.IndexOf(2));
    }

    [Theory]
    [InlineData(0, 23, new int[]{23,1,2,3})]
    [InlineData(2, 23, new int[]{1,2,23,3})]
    [InlineData(1, 23, new int[]{1,23,2,3})]
    public void Insert_FromEmptyToDifferentParts_ReturnsTrue(int index, int value, int[] expected)
    {
        var list = InitializeIntLinkedList();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        
        list.Insert(index, value);
        bool result = Enumerable.SequenceEqual(IntLinkesListToArray(list), expected);
        Assert.True(result);
    }

    [Fact]
    public void Insert_IndexOutOfRange_ThrowsError()
    {
        var list = InitializeIntLinkedList();
        Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(1, 2));
    }

    [Fact]
    public void Contains_NoSuchElement_ReturnFalse()
    {
        var list = InitializeIntLinkedList();
        Assert.False(list.Contains(2));
    }

    [Fact]
    public void Contains_ElementExists_ReturnTrue()
    {
        var list = InitializeIntLinkedList();
        list.Add(2);
        Assert.True(list.Contains(2));
    }

    [Fact]
    public void Clear_HasElements_ReturnTrue()
    {
        var list = InitializeIntLinkedList();
        list.Add(1);
        list.Clear();
        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void Clear_DoesntHaveElements_ReturnTrue()
    {
        var list = InitializeIntLinkedList();
        list.Clear();
        Assert.Equal(0, list.Count);
    }
}