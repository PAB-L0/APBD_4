namespace Labs_4.Classes;

public class Appointment(int animalId, DateTime date, string description, double price)
{
    public int AnimalId { get; set; } = animalId;
    public DateTime Date { get; set; } = date;
    public string Description { get; set; } = description;
    public double Price { get; set; } = price;
}