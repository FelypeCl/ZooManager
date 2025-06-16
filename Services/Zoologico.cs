using System;
using System.Linq;
using ZoologicoManager.Enums;
using ZoologicoManager.Models.Animais;
using ZoologicoManager.Models.Pessoas;
using ZoologicoManager.Models.Recintos;
using ZoologicoManager.UI;
namespace ZoologicoManager.Services;

public class Zoologico
{
	private List<Recinto> Recintos { get; }
    private List<Funcionario> Funcionarios { get; }

	public Zoologico()
	{
        Recintos = new List<Recinto>();
        Funcionarios = new List<Funcionario>();

        Recinto recinto = new Recinto("SAVANA", 300, Bioma.SAVANA); //Recinto Pre-definido pra DEBUG

        AdicionarRecinto(recinto);
    }

	public void AdicionarRecinto(Recinto recinto)
	{
		Console.WriteLine($"Adicionando {recinto.Nome} à lista de recintos...");
		Recintos.Add(recinto);
		Console.WriteLine("Recinto adicionado!");
	}

	public Dictionary<string, double> CalcularAlimentos()
	{
		Dictionary<string, double> Alimentos = new Dictionary<string, double>();

		Alimentos.Add("Carnes", Recintos.Sum(e => e.Animais.Count(r => r is Mamifero) * 2.5));
		Alimentos.Add("Sementes", Recintos.Sum(e => e.Animais.Count(r => r is Ave) * 1.2));
		Alimentos.Add("Insetos", Recintos.Sum(e => e.Animais.Count(r => r is Reptil) * 0.8));

		return Alimentos;
	}

	public void ListarAnimaisPorTipo()
	{
        Console.Clear();
        Console.WriteLine("═════════════════════════════");
        Console.WriteLine("   LISTAR ANIMAIS CADASTRADOS");
        Console.WriteLine("═════════════════════════════");

        var animaisAgrupados = Recintos
        .SelectMany(r => r.Animais)
        .GroupBy(a => a.GetType().Name)
        .OrderBy(g => g.Key);

        int totalAnimais = Recintos.Sum(r => r.Animais.Count);

        if (totalAnimais == 0)
        {
            Console.WriteLine("\nNão há nenhum animal no Zoológico");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            return;
        }

        foreach (var grupo in animaisAgrupados)
        {
            Console.WriteLine($"\n> {grupo.Key.ToUpper()} <");
            Console.WriteLine("------------------------------------------");

            foreach (var animal in grupo.OrderBy(a => a.Nome))
            {
                string infoEspecifica = ObterInfoEspecifica(animal);
                Console.WriteLine($" - ID: {animal.Id} | Nome: {animal.Nome} | Idade: {animal.Idade} anos");
                Console.WriteLine($"   Alimentação: {animal.Alimentacao.Tipo} | {infoEspecifica}");
                Console.WriteLine("------------------------------------------");
            }
        }

        if (GerenciadorMenu.isRemovendoAnimal)
        {
            Console.WriteLine("\nTotal de animais: " + totalAnimais);
            GerenciadorMenu.isRemovendoAnimal = false;
        } else
        {
            Console.WriteLine("\nTotal de animais: " + totalAnimais);
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
        }

    }

    public void AdicionarAnimalRecinto(string nomeDoRecinto, Animal animal)
    {
        foreach (Recinto recinto in Recintos)
        {
            if (recinto.Nome == nomeDoRecinto)
            {
                recinto.AdicionarAnimalRecinto(animal);
            }
        }
    }

    public void RemoverAnimalRecinto(string nomeDoRecinto, int id)
    {
        foreach (Recinto recinto in Recintos)
        {
            if (recinto.Nome == nomeDoRecinto)
            {
                recinto.RemoverAnimalRecinto(id);
            }
        }
    }

    private string ObterInfoEspecifica(Animal animal)
    {
        switch (animal)
        {
            case Mamifero m:
                return $"Gestação: {m.Gestacao} dias";
            case Ave a:
                return $"Envergadura: {a.EnvergaduraAsa} cm";
            case Reptil r:
                return $"Troca de pele: {(r.TrocaDePele ? "Sim" : "Não")}";
            default:
                return "Tipo genérico";
        }
    }
}
