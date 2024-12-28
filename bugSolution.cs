//Improved class with explicit checks and error handling
public class MyClass
{
    public int MyProperty { get; set; }

    public MyClass(int value)
    {
        MyProperty = value;
    }

    public static explicit operator int(MyClass obj) // Explicit conversion
    {
        if (obj == null) { throw new ArgumentNullException(nameof(obj)); }
        return obj.MyProperty;
    }

    public static explicit operator MyClass(int value)
    {
        if (value < 0) { throw new ArgumentOutOfRangeException(nameof(value), "Value cannot be negative."); }
        return new MyClass(value);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        MyClass obj1 = (MyClass)5; // Explicit conversion from int to MyClass
        int num = (int)obj1;    // Explicit conversion from MyClass to int
        Console.WriteLine(num); // Output: 5

        try
        {
            MyClass obj2 = new MyClass(10);
            int num2 = (int)obj2 + 5; // Explicit conversion from MyClass to int, and then addition
            Console.WriteLine(num2); // Output: 15
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("Exception Caught: " + ex.Message);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Exception Caught: " + ex.Message);
        }
    }
}