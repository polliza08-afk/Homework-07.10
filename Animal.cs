namespace MyCollection;

public abstract class Animal
{
    protected string _name;
    protected int _age;

    public Animal()
    {
        _name = "No Name";
        _age = 0;
    }

    public Animal(string name, int age)
    {
        _name = name;
        _age = age;
    }

    public override string ToString()
    {
        string str = "Name: " + _name + "\n";
        str += $"Age: {_age}";
        return str;
    }
}
