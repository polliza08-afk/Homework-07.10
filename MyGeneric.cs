namespace MyCollection;

public class MyGeneric
{
    private object[] _items;

    public int Count => _items.Length; //Властивість для перевірки кількості тварин

    public MyGeneric()
    {
        _items = new object[0];
    }

    public void Add(object item)
    {
        int count = _items.Length;
        object[] temp = new object[count + 1];
        for (int i = 0; i < count; i++)
            temp[i] = _items[i];
        temp[count] = item;
        _items = temp;
    }

    public object? Find(object item)
    {
        foreach (var i in _items)
        {
            if (i is Dog myDog && item is Dog searchDog)
            {
                if (myDog == searchDog) return i;
            }
            else if (i is Cat myCat && item is Cat searchCat)
            {
                if (myCat == searchCat) return i;
            }
            else if (i != null && i.Equals(item))
            {
                return i;
            }
        }
        return null;
    }

    public void ViewItems()
    {
        if (_items.Length == 0)
        {
            Console.WriteLine("Притулок порожній.");
            return;
        }

        foreach (object item in _items)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine(item);
        }
        Console.WriteLine("-------------------");
    }
}
