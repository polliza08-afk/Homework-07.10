// See https://aka.ms/new-console-template for more information

using MyCollection;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("-- Притулок для тварин --");

int action = 0;
MyGeneric myList = new MyGeneric();

do
{
    Console.WriteLine("\n0. Вийти");
    Console.WriteLine("1. Додати тварину у притулок");
    Console.WriteLine("2. Показати усіх тварин притулку");
    Console.WriteLine("3. Пошук тварини");
    Console.Write("Виберіть дію: ");

    if (!int.TryParse(Console.ReadLine(), out action))
    {
        Console.WriteLine("Будь ласка, введіть число!");
        continue;
    }

    switch (action)
    {
        case 1:
            AddAnimal();
            break;
        case 2:
            myList.ViewItems();
            break;
        case 3:
            FindAnimal();
            break;
        case 0:
            Console.WriteLine("До побачення!");
            break;
        default:
            Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
            break;
    }

} while (action != 0);


void AddAnimal()
{
    //Перевірка ліміту притулку
    if (myList.Count >= 2)
    {
        Console.WriteLine("Помилка: Притулок переповнений! Максимальна кількість тварин — 2.");
        return;
    }

    Console.WriteLine("Виберіть тип тварини:");
    Console.WriteLine("1. Собака (Dog)");
    Console.WriteLine("2. Кіт (Cat)");
    Console.Write("Ваш вибір: ");
    string choice = Console.ReadLine();

    Console.Write("Введіть ім'я тварини: ");
    string name = Console.ReadLine();

    Console.Write("Введіть вік тварини: ");
    if (!int.TryParse(Console.ReadLine(), out int age))
    {
        Console.WriteLine("Некоректний вік!");
        return;
    }

    Animal animal;
    if (choice == "1")
    {
        animal = new Dog(name, age);
    }
    else if (choice == "2")
    {
        animal = new Cat(name, age);
    }
    else
    {
        Console.WriteLine("Невідомий тип тварини!");
        return;
    }

    myList.Add(animal);
    Console.WriteLine("Тварину успішно додано до притулку!");
}


void FindAnimal()
{
    Console.WriteLine("Яку тварину шукаємо?");
    Console.WriteLine("1. Собака (Dog)");
    Console.WriteLine("2. Кіт (Cat)");
    Console.Write("Ваш вибір: ");
    string choice = Console.ReadLine();

    Console.Write("Введіть ім'я тварини: ");
    string name = Console.ReadLine();

    Console.Write("Введіть вік тварини: ");
    if (!int.TryParse(Console.ReadLine(), out int age))
    {
        Console.WriteLine("Некоректний вік!");
        return;
    }

    object searchTarget = null;
    if (choice == "1")
    {
        searchTarget = new Dog(name, age);
    }
    else if (choice == "2")
    {
        searchTarget = new Cat(name, age);
    }
    else
    {
        Console.WriteLine("Невідомий тип тварини!");
        return;
    }

    var foundAnimal = myList.Find(searchTarget);
    if (foundAnimal != null)
    {
        Console.WriteLine("Тварину знайдено:\n" + foundAnimal);
    }
    else
    {
        Console.WriteLine("Тварину не знайдено у притулку.");
    }
}
