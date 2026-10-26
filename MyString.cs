using System;

public class MyString : IComparable<MyString>
{
    private string _value;
    private int _encryptionKey;

    public string Value => _value;
    public int Length => _value?.Length ?? 0;
    public int EncryptionKey => _encryptionKey;

    public MyString(string value, int encryptionKey)
    {
        _value = value ?? string.Empty;
        _encryptionKey = encryptionKey;
    }

    public void Encrypt()
    {
        char[] buffer = _value.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            buffer[i] = (char)(buffer[i] + _encryptionKey);
        }
        _value = new string(buffer);
    }

    public void Decrypt()
    {
        char[] buffer = _value.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            buffer[i] = (char)(buffer[i] - _encryptionKey);
        }
        _value = new string(buffer);
    }

    public void Print()
    {
        Console.WriteLine($"Рядок: \"{_value}\" | Довжина: {Length} | Ключ: {_encryptionKey}");
    }

    public override string ToString()
    {
        return $"\"{_value}\" (L:{Length})";
    }

    public int CompareTo(MyString? other)
    {
        if (other == null) return 1;
        return string.Compare(_value, other._value, StringComparison.Ordinal);
    }
}