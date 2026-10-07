namespace MyCollection;

public class Dog : Animal
{
    public Dog() : base() { }

    public Dog(string name, int age) : base(name, age) { }

    public static bool operator ==(Dog d1, Dog d2)
    {
        if (ReferenceEquals(d1, d2)) return true;
        if (d1 is null || d2 is null) return false;
        return d1._name.Equals(d2._name) && d1._age == d2._age;
    }

    public static bool operator !=(Dog d1, Dog d2)
    {
        return !(d1 == d2);
    }

    public override bool Equals(object? obj) => obj is Dog dog && this == dog;
    public override int GetHashCode() => HashCode.Combine(_name, _age);
}
