namespace Labs_4.Classes;

public class Database
{
    private readonly List<Animal> _animals =
    [
        new Animal("Alpha", "Cat", "Gray", 3.75),
        new Animal("Beta", "Cat", "Orange", 4.25),
        new Animal("Gamma", "Dog", "White", 4.75)
    ];

    private readonly List<Appointment> _appointments =
    [
        new Appointment(1, DateTime.Parse("2000-01-01 07:45:00"), "Treatment", 199.99),
        new Appointment(1, DateTime.Parse("2000-01-10 07:45:00"), "Control", 49.99),
        new Appointment(2, DateTime.Parse("2000-01-01 08:15:00"), "Treatment", 99.99),
        new Appointment(2, DateTime.Parse("2000-01-10 08:15:00"), "Control", 49.99),
        new Appointment(3, DateTime.Parse("2000-01-01 08:45:00"), "Surgery", 199.99)
    ];

    public List<Animal> GetAnimals()
    {
        return _animals;
    }

    public Animal? GetAnimal(int id)
    {
        return _animals.FirstOrDefault(animal => animal.Id == id);
    }

    public void AddAnimal(Animal animal)
    {
        _animals.Add(animal);
    }

    public void EditAnimal(Animal currentAnimal, Animal futureAnimal)
    {
        _animals[_animals.IndexOf(currentAnimal)] = futureAnimal;
    }

    public void DeleteAnimal(Animal animal)
    {
        _animals.Remove(animal);
    }

    public List<Appointment> GetAppointments(int id)
    {
        return _appointments.Where(appointment => appointment.AnimalId == id).ToList();
    }

    public void AddAppointment(Appointment appointment)
    {
        _appointments.Add(appointment);
    }
}