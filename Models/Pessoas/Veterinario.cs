using System;
using ZoologicoManager.Services;
namespace ZoologicoManager.Models.Pessoas;

public class Veterinario : Funcionario
{
	private List<string> Prontuario {  get; }

	public Veterinario(string nome, string cargo) : base(nome, cargo)
	{
        Prontuario = new List<string>();
	}

	public void ExaminarAnimal(IAnimalVeterinavel animal)
	{
        Console.WriteLine("Iniciando protocolo de exame...");
        animal.PrepararParaExame();  // Chama o método do animal
        Console.WriteLine("Registrando no prontuário...");
    }

	public void AdicionarProntuario(IAnimalVeterinavel animal)
	{

	}

    public void RemoverProntuario(IAnimalVeterinavel animal)
    {

    }
}
