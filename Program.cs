using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== Колекції, масиви та основні операції ===");

        MyString[] array = new MyString[]
        {
            new MyString("Banana", 2),
            new MyString("Apple", 3),
            new MyString("Cherry", 1)
        };

        List<MyString> genericList = new List<MyString>(array);

        ArrayList nonGenericList = new ArrayList();
        foreach (var item in array) nonGenericList.Add(item);

        MyString newItem = new MyString("Date", 4);
        genericList.Add(newItem);
        nonGenericList.Add(newItem);

        genericList[0] = new MyString("Apricot", 2);

        genericList.RemoveAt(1);

        MyString? found = genericList.Find(x => x.Value == "Date");
        Console.WriteLine($"Знайдений елемент у List<T>: {found}");

        Console.WriteLine("\nПрохід по Generic List:");
        foreach (var str in genericList)
        {
            str.Print();
        }

        Console.WriteLine("\n=== Бінарне дерево (Preorder) та Порівняння ===");

        MyString[] items = new MyString[]
        {
            new MyString("Mango", 3),
            new MyString("Apple", 1),
            new MyString("Peach", 4),
            new MyString("Banana", 2),
            new MyString("Orange", 5),
            new MyString("Plum", 2)
        };

        BinaryTree<MyString> tree = new BinaryTree<MyString>();
        foreach (var item in items)
        {
            tree.Add(item);
        }

        Console.WriteLine("\nОбхід дерева у прямому порядку (preorder) за допомогою власних IEnumerable/IEnumerator:");
        foreach (var node in tree)
        {
            Console.WriteLine(node);
        }

        Console.WriteLine("\n--- Демонстрація шифрування/дешифрування ---");
        MyString sample = new MyString("Hello World", 5);
        sample.Print();
        
        sample.Encrypt();
        Console.Write("Зашифровано: ");
        sample.Print();

        sample.Decrypt();
        Console.Write("Дешифровано: ");
        sample.Print();

        Console.WriteLine("\n--- Сортування колекції за допомогою IComparer<T> (за довжиною) ---");
        genericList.Sort(new MyStringLengthComparer());
        foreach (var str in genericList)
        {
            Console.WriteLine(str);
        }
    }
}