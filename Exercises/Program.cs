// See https://aka.ms/new-console-template for more information

using CarXCodingExercises;

ListX<int> list = new ListX<int>();
list.Add(1);
list.Add(1);
list.Add(1);
list.Add(1);
list.Add(1);
list.Clear();
Console.WriteLine(list);
list.Add(5);
Console.WriteLine(list);
list.Insert(1, 3);
Console.WriteLine(list);
list.Capacity = 0;
Console.WriteLine(list);
list.Add(1);
list.Add(1);
list.Add(1);
list.Remove(3);
Console.WriteLine(list);
list.RemoveAt(0);
Console.WriteLine(list);