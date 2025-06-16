using System;
using ZoologicoManager.Enums;
using ZoologicoManager.Models.Animais;
namespace ZoologicoManager.Models.Recintos;

public class Recinto
{
	public string Nome {  get; set; }
	public double Area {  get; set; }
    public Bioma Bioma { get; set; }
    public List<Animal> Animais { get; }

	public Recinto(string nome, double area, Bioma bioma)
	{
        Nome = nome;
        Area = area;
        Bioma = bioma;
        Animais = new List<Animal>();
	}

	public void AdicionarAnimalRecinto(Animal animal)
	{
        Console.WriteLine($"\nAdicionando {animal.Nome} ao recinto {Nome}...");
        Animais.Add(animal);
        Console.WriteLine("Animal adicionado ao recinto!");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
    }

	public void RemoverAnimalRecinto(int idAnimal)
	{
        var animal = Animais.FirstOrDefault(a => a.Id == idAnimal) ?? throw new InvalidOperationException("Animal não encontrado.");
        Console.WriteLine($"\nRemovendo {animal.Nome} do recinto {Nome}...");
        Animais.Remove(animal);
        Console.WriteLine("Animal removido do recinto!");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
    }

	public bool VerificarCompatibilidade(Animal animal)
	{
		return false;
	}
}
