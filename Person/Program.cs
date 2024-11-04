using System;

class Person
{
    
    private string name;
    private DateTime birthYear;

    public string Name => name;
    public DateTime BirthYear => birthYear;

    
    public Person()
    {
        name = "Unknown";
        birthYear = DateTime.Now;
    }

    // Конструктор з параметрами
    public Person(string name, DateTime birthYear)
    {
        this.name = name;
        this.birthYear = birthYear;
    }

    public int Age()
    {
        int age = DateTime.Now.Year - birthYear.Year;
        if (DateTime.Now.DayOfYear < birthYear.DayOfYear)
            age--;
        return age;
    }

    public void Input()
    {
        Console.WriteLine("Enter name:");
        name = Console.ReadLine();

        Console.WriteLine("Enter birth year (yyyy):");
        int year = Convert.ToInt32(Console.ReadLine());
        birthYear = new DateTime(year, 1, 1);
    }

    
    public void ChangeName(string newName)
    {
        name = newName;
    }

    
    public override string ToString()
    {
        return $"Name: {name}, Age: {Age()}";
    }

    // Метод для виведення інформації про особу
    public void Output()
    {
        Console.WriteLine(ToString());
    }

    // Перевантаження оператора ==
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
            return false;
        Person p = (Person)obj;
        return name == p.name;
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
      
        Person[] people = new Person[6];

       
        for (int i = 0; i < 6; i++)
        {
            people[i] = new Person();
            people[i].Input();
        }

      
        Console.WriteLine("\nList of people:");
        foreach (var person in people)
        {
            Console.WriteLine($"{person.Name}, Age: {person.Age()}");
        }

        Console.WriteLine("\nChanging name for persons under 16...");
        foreach (var person in people)
        {
            if (person.Age() < 16)
            {
                person.ChangeName("Very Young");
            }
        }

        
        Console.WriteLine("\nUpdated list of people:");
        foreach (var person in people)
        {
            person.Output();
        }

      
        Console.WriteLine("\nFinding people with the same name:");
        for (int i = 0; i < people.Length; i++)
        {
            for (int j = i + 1; j < people.Length; j++)
            {
                if (people[i] == people[j])
                {
                    Console.WriteLine($"Same name found: {people[i].ToString()} and {people[j].ToString()}");
                }
            }
        }
    }
}
