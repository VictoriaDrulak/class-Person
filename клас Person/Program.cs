public class Person
{
    private string name;
    private DateTime birthYear;
    public string Name
    {
        get { return name; }
    }

    public DateTime BirthYear
    {
        get { return birthYear; }
    }

    public Person()
    {
        name = "Unknown";
        birthYear = DateTime.Now;
    }

    public Person(string name, DateTime birthYear)
    {
        this.name = name;
        this.birthYear = birthYear;
    }

    public int Age()
    {
        int currentYear = DateTime.Now.Year;
        return currentYear - birthYear.Year;
    }

    public void ChangeName(string newName)
    {
        name = newName;
    }

    public void Input()
    {
        Console.Write("Введіть ім'я ");
        name = Console.ReadLine();

        Console.Write("Введіть рік народження (формат: рік-місяць-день): ");
        birthYear = DateTime.Parse(Console.ReadLine());
    }

    public override string ToString()
    {
        return $"Ім'я: {name}, Рік народження: {birthYear.Year}, Вік: {Age()}";
    }

    public void Output()
    {
        Console.WriteLine(ToString());
    }

    public static bool operator ==(Person p1, Person p2)
    {
        return p1.name == p2.name;
    }

    public static bool operator !=(Person p1, Person p2)
    {
        return !(p1 == p2);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Person other = (Person)obj;
        return name == other.name;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person[] persons = new Person[6];

        for (int i = 0; i < persons.Length; i++)
        {
            persons[i] = new Person();
            Console.WriteLine($"\nВведіть інфоhvfws. про особу #{i + 1}:");
            persons[i].Input();
        }

        Console.WriteLine("\nІм'я та вік кожного");
        foreach (var person in persons)
        {
            Console.WriteLine($"Ім'я: {person.Name}, Вік: {person.Age()}");
        }

        foreach (var person in persons)
        {
            if (person.Age() < 16)
            {
                person.ChangeName("Very Young");
            }
        }

        Console.WriteLine("\nЗмінена інформація про осіб:");
        foreach (var person in persons)
        {
            person.Output();
        }


        Console.WriteLine("\nЛюди з однаковими іменами:");
        for (int i = 0; i < persons.Length; i++)
        {
            for (int j = i + 1; j < persons.Length; j++)
            {
                if (persons[i] == persons[j])
                {
                    Console.WriteLine($"Ім'я: {persons[i].Name}");
                    persons[i].Output();
                    persons[j].Output();
                }
            }
        }
    }
}