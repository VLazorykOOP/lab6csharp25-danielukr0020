////task1
//using System;

//// Інтерфейси
//interface IPerson
//{
//    string Name { get; set; }
//    int Age { get; set; }
//}

//interface IEmployee : IPerson, IDisposable, IShowable
//{
//    double Salary { get; set; }
//    void Work();
//}


//interface IShowable
//{
//    void Show();
//}

//// Реалізація працівників
//abstract class Employee : IEmployee, IShowable
//{
//    public string Name { get; set; }
//    public int Age { get; set; }
//    public double Salary { get; set; }

//    protected Employee(string name, int age, double salary)
//    {
//        Name = name;
//        Age = age;
//        Salary = salary;
//    }

//    public abstract void Work();
//    public abstract void Show();

//    public void Dispose()
//    {
//        Console.WriteLine($"Ресурси для {Name} звільнено.");
//    }
//}

//class Worker : Employee
//{
//    public string WorkArea { get; set; }

//    public Worker(string name, int age, double salary, string workArea)
//        : base(name, age, salary)
//    {
//        WorkArea = workArea;
//    }

//    public override void Work() => Console.WriteLine($"{Name} працює у {WorkArea}.");
//    public override void Show() => Console.WriteLine($"Робітник: {Name}, Вік: {Age}, Зарплата: {Salary}, Область роботи: {WorkArea}");
//}

//class HR : Employee
//{
//    public int EmployeesManaged { get; set; }

//    public HR(string name, int age, double salary, int employeesManaged)
//        : base(name, age, salary)
//    {
//        EmployeesManaged = employeesManaged;
//    }

//    public override void Work() => Console.WriteLine($"{Name} керує {EmployeesManaged} співробітниками.");
//    public override void Show() => Console.WriteLine($"Кадри: {Name}, Вік: {Age}, Зарплата: {Salary}, Кількість співробітників: {EmployeesManaged}");
//}

//class Engineer : Employee
//{
//    public string Specialization { get; set; }

//    public Engineer(string name, int age, double salary, string specialization)
//        : base(name, age, salary)
//    {
//        Specialization = specialization;
//    }

//    public override void Work() => Console.WriteLine($"{Name} працює в галузі {Specialization}.");
//    public override void Show() => Console.WriteLine($"Інженер: {Name}, Вік: {Age}, Зарплата: {Salary}, Спеціалізація: {Specialization}");
//}

//// Адміністрація
//record Administration(string Name, int Age, double Salary, string Position) : IShowable
//{
//    public void Show() => Console.WriteLine($"Адміністрація: {Name}, Вік: {Age}, Зарплата: {Salary}, Посада: {Position}");
//}

//class Program
//{
//    static void Main()
//    {
//        IEmployee worker = new Worker("Іван", 35, 20000, "Будівництво");
//        IEmployee hr = new HR("Марина", 40, 25000, 100);
//        IEmployee engineer = new Engineer("Олексій", 30, 30000, "Програмування");
//        IShowable admin = new Administration("Олена", 45, 50000, "Директор");

//        worker.Show();
//        hr.Show();
//        engineer.Show();
//        admin.Show();

//        worker.Dispose();
//        hr.Dispose();
//        engineer.Dispose();
//    }
//}



////task2
//using System;
//using System.Collections.Generic;
//using System.Linq;

//// Інтерфейс Видання, який успадковує інтерфейси .NET
//interface IPublication : IComparable<IPublication>, IDisposable
//{
//    string Title { get; }
//    string Author { get; }
//    void DisplayInfo();
//    bool IsMatching(string searchAuthor);
//}

//// Базовий клас Видання
//abstract class Publication : IPublication
//{
//    public string Title { get; }
//    public string Author { get; }

//    protected Publication(string title, string author)
//    {
//        Title = title;
//        Author = author;
//    }

//    public abstract void DisplayInfo();

//    public bool IsMatching(string searchAuthor)
//    {
//        return Author.Equals(searchAuthor, StringComparison.OrdinalIgnoreCase);
//    }

//    public int CompareTo(IPublication? other)
//    {
//        return Title.CompareTo(other?.Title);
//    }

//    public void Dispose()
//    {
//        Console.WriteLine($"Ресурс {Title} звільнено.");
//    }
//}

//// Клас Книга
//class Book : Publication
//{
//    public int Year { get; }
//    public string Publisher { get; }

//    public Book(string title, string author, int year, string publisher)
//        : base(title, author)
//    {
//        Year = year;
//        Publisher = publisher;
//    }

//    public override void DisplayInfo()
//    {
//        Console.WriteLine($"Книга: {Title}, Автор: {Author}, Рік: {Year}, Видавництво: {Publisher}");
//    }
//}

//// Клас Стаття
//class Article : Publication
//{
//    public string Journal { get; }
//    public int IssueNumber { get; }
//    public int Year { get; }

//    public Article(string title, string author, string journal, int issueNumber, int year)
//        : base(title, author)
//    {
//        Journal = journal;
//        IssueNumber = issueNumber;
//        Year = year;
//    }

//    public override void DisplayInfo()
//    {
//        Console.WriteLine($"Стаття: {Title}, Автор: {Author}, Журнал: {Journal}, Номер: {IssueNumber}, Рік: {Year}");
//    }
//}

//// Клас Електронний ресурс
//class EResource : Publication
//{
//    public string URL { get; }
//    public string Annotation { get; }

//    public EResource(string title, string author, string url, string annotation)
//        : base(title, author)
//    {
//        URL = url;
//        Annotation = annotation;
//    }

//    public override void DisplayInfo()
//    {
//        Console.WriteLine($"Електронний ресурс: {Title}, Автор: {Author}, Посилання: {URL}, Анотація: {Annotation}");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        List<IPublication> catalog = new()
//        {
//            new Book("Пригоди Шерлока Холмса", "Артур Конан Дойл", 1892, "Видавництво XYZ"),
//            new Article("Квантова механіка", "Вернер Гейзенберг", "Науковий вісник", 3, 1925),
//            new EResource("Вступ до C#", "Джон Сміт", "https://example.com/csharp", "Основи програмування на C#")
//        };

//        // Виведення всього каталогу
//        Console.WriteLine("Каталог видань:");
//        foreach (var item in catalog)
//        {
//            item.DisplayInfo();
//        }

//        // Пошук за автором
//        Console.Write("\nВведіть прізвище автора для пошуку: ");
//        string searchAuthor = Console.ReadLine();
//        var foundItems = catalog.Where(p => p.IsMatching(searchAuthor)).ToList();

//        if (foundItems.Any())
//        {
//            Console.WriteLine("\nЗнайдені видання:");
//            foundItems.ForEach(item => item.DisplayInfo());
//        }
//        else
//        {
//            Console.WriteLine("\nВидання цього автора не знайдено.");
//        }
//    }
//}






////task3
//using System;
//using System.Collections.Generic;
//using System.Linq;

//// Власний виняток для некоректного індексу
//class PublicationNotFoundException : Exception
//{
//    public PublicationNotFoundException(string message) : base(message) { }
//}

//// Інтерфейс Видання, який успадковує інтерфейси .NET
//interface IPublication : IComparable<IPublication>, IDisposable
//{
//    string Title { get; }
//    string Author { get; }
//    void DisplayInfo();
//    bool IsMatching(string searchAuthor);
//}

//// Базовий клас Видання
//abstract class Publication : IPublication
//{
//    public string Title { get; }
//    public string Author { get; }

//    protected Publication(string title, string author)
//    {
//        Title = title;
//        Author = author;
//    }

//    public abstract void DisplayInfo();

//    public bool IsMatching(string searchAuthor)
//    {
//        return Author.Equals(searchAuthor, StringComparison.OrdinalIgnoreCase);
//    }

//    public int CompareTo(IPublication? other)
//    {
//        return Title.CompareTo(other?.Title);
//    }

//    public void Dispose()
//    {
//        Console.WriteLine($"Ресурс {Title} звільнено.");
//    }
//}

//// Клас Книга
//class Book : Publication
//{
//    public int Year { get; }
//    public string Publisher { get; }

//    public Book(string title, string author, int year, string publisher)
//        : base(title, author)
//    {
//        Year = year;
//        Publisher = publisher;
//    }

//    public override void DisplayInfo()
//    {
//        Console.WriteLine($"Книга: {Title}, Автор: {Author}, Рік: {Year}, Видавництво: {Publisher}");
//    }
//}

//// Клас Стаття
//class Article : Publication
//{
//    public string Journal { get; }
//    public int IssueNumber { get; }
//    public int Year { get; }

//    public Article(string title, string author, string journal, int issueNumber, int year)
//        : base(title, author)
//    {
//        Journal = journal;
//        IssueNumber = issueNumber;
//        Year = year;
//    }

//    public override void DisplayInfo()
//    {
//        Console.WriteLine($"Стаття: {Title}, Автор: {Author}, Журнал: {Journal}, Номер: {IssueNumber}, Рік: {Year}");
//    }
//}

//// Клас Електронний ресурс
//class EResource : Publication
//{
//    public string URL { get; }
//    public string Annotation { get; }

//    public EResource(string title, string author, string url, string annotation)
//        : base(title, author)
//    {
//        URL = url;
//        Annotation = annotation;
//    }

//    public override void DisplayInfo()
//    {
//        Console.WriteLine($"Електронний ресурс: {Title}, Автор: {Author}, Посилання: {URL}, Анотація: {Annotation}");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        List<IPublication> catalog = new()
//        {
//            new Book("Пригоди Шерлока Холмса", "Артур Конан Дойл", 1892, "Видавництво XYZ"),
//            new Article("Квантова механіка", "Вернер Гейзенберг", "Науковий вісник", 3, 1925),
//            new EResource("Вступ до C#", "Джон Сміт", "https://example.com/csharp", "Основи програмування на C#"),
//            new Book("1984", "Джордж Орвелл", 1949, "Secker & Warburg"),
//            new Article("Теорія відносності", "Альберт Ейнштейн", "Фізичний журнал", 5, 1905),
//            new EResource("Алгоритми і структури даних", "Роберт Седжвік", "https://example.com/algorithms", "Книга з алгоритмів")
//        };

//        try
//        {
//            // Виведення всього каталогу
//            Console.WriteLine("Каталог видань:");
//            foreach (var item in catalog)
//            {
//                item.DisplayInfo();
//            }

//            // Пошук за автором
//            Console.Write("\nВведіть прізвище автора для пошуку: ");
//            string searchAuthor = Console.ReadLine();
//            var foundItems = catalog.Where(p => p.IsMatching(searchAuthor)).ToList();

//            if (!foundItems.Any())
//                throw new PublicationNotFoundException("Видання цього автора не знайдено.");

//            Console.WriteLine("\nЗнайдені видання:");
//            foundItems.ForEach(item => item.DisplayInfo());

//            // Спроба доступу до некоректного індексу
//        }
//        catch (PublicationNotFoundException ex)
//        {
//            Console.WriteLine($"Помилка: {ex.Message}");
//        }
//        catch (IndexOutOfRangeException)
//        {
//            Console.WriteLine("Помилка: Невірний індекс доступу до каталогу.");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Сталася невідома помилка: {ex.Message}");
//        }
//    }
//}






//task4
using System;
using System.Collections;
using System.Collections.Generic;

class VectorShort : IEnumerable<short>
{
    protected short[] ShortArray;
    protected uint n;
    protected uint codeError;
    protected static uint num_v = 0;

    // Конструктор без параметрів
    public VectorShort()
    {
        n = 1;
        ShortArray = new short[n];
        ShortArray[0] = 0;
        num_v++;
    }

    // Конструктор з одним параметром (розмір вектора)
    public VectorShort(uint size)
    {
        n = size;
        ShortArray = new short[n];
        num_v++;
    }

    // Конструктор з двома параметрами (розмір і значення ініціалізації)
    public VectorShort(uint size, short value)
    {
        n = size;
        ShortArray = new short[n];
        for (int i = 0; i < n; i++)
            ShortArray[i] = value;
        num_v++;
    }

    // Деструктор
    ~VectorShort()
    {
        Console.WriteLine("VectorShort object is being deleted");
    }

    // Метод для введення елементів вектора
    public void InputElements()
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter element [{i}]: ");
            ShortArray[i] = short.Parse(Console.ReadLine());
        }
    }

    // Метод для виведення елементів вектора
    public void PrintElements()
    {
        Console.WriteLine("Vector elements: " + string.Join(", ", ShortArray));
    }

    // Властивість для отримання розміру вектора
    public uint Size => n;

    // Властивість для роботи з codeError
    public uint CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор
    public short this[int index]
    {
        get
        {
            if (index < 0 || index >= n)
            {
                codeError = 10;
                return 0;
            }
            return ShortArray[index];
        }
        set
        {
            if (index < 0 || index >= n)
                codeError = 10;
            else
                ShortArray[index] = value;
        }
    }

    // Перевантаження оператора ++
    public static VectorShort operator ++(VectorShort v)
    {
        for (int i = 0; i < v.n; i++)
            v.ShortArray[i]++;
        return v;
    }

    // Перевантаження оператора --
    public static VectorShort operator --(VectorShort v)
    {
        for (int i = 0; i < v.n; i++)
            v.ShortArray[i]--;
        return v;
    }

    // Перевантаження оператора ! (логічне заперечення)
    public static bool operator !(VectorShort v)
    {
        return v.n == 0;
    }

    // Перевантаження оператора ~ (побітове заперечення)
    public static VectorShort operator ~(VectorShort v)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
            result.ShortArray[i] = (short)~v.ShortArray[i];
        return result;
    }

    // Перевантаження операторів +, -, *, /
    public static VectorShort operator +(VectorShort v1, VectorShort v2)
    {
        uint maxSize = Math.Max(v1.n, v2.n);
        VectorShort result = new VectorShort(maxSize);
        for (int i = 0; i < maxSize; i++)
            result.ShortArray[i] = (short)(v1[i] + v2[i]);
        return result;
    }

    public static VectorShort operator +(VectorShort v, short scalar)
    {
        VectorShort result = new VectorShort(v.n);
        for (int i = 0; i < v.n; i++)
            result.ShortArray[i] = (short)(v.ShortArray[i] + scalar);
        return result;
    }

    // Операція порівняння ==
    public static bool operator ==(VectorShort v1, VectorShort v2)
    {
        if (v1.n != v2.n) return false;
        for (int i = 0; i < v1.n; i++)
            if (v1.ShortArray[i] != v2.ShortArray[i])
                return false;
        return true;
    }

    public static bool operator !=(VectorShort v1, VectorShort v2)
    {
        return !(v1 == v2);
    }

    // Метод для отримання кількості векторів
    public static uint GetVectorCount()
    {
        return num_v;
    }

    // Реалізація IEnumerable<short>
    public IEnumerator<short> GetEnumerator()
    {
        foreach (var item in ShortArray)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        VectorShort v1 = new VectorShort(3, 5);
        VectorShort v2 = new VectorShort(3, 2);

        Console.WriteLine("Initial vectors:");
        v1.PrintElements();
        v2.PrintElements();

        VectorShort sum = v1 + v2;
        Console.WriteLine("Sum of vectors:");
        sum.PrintElements();

        Console.WriteLine("Iterating over vector v1 using foreach:");
        foreach (var value in v1)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();

        Console.ReadKey();
    }
}
