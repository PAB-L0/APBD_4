namespace Labs_4.Classes;

public class Animal(string name, string species, string hairColor, double weight)
{
    private static int _id = 1;
    public int Id { get; } = _id++;
    public string Name { get; } = name;
    public string Species { get; } = species;
    public string HairColor { get; set; } = hairColor;
    public double Weight { get; set; } = weight;
}