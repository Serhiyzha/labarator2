using System.Collections.Generic;

public class MyStringLengthComparer : IComparer<MyString>
{
    public int Compare(MyString? x, MyString? y)
    {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;

        return x.Length.CompareTo(y.Length);
    }
}