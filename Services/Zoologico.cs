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
    private List<Visitante> Visitantes { get;  }

	public Zoologico()
	{
        Recintos = new List<Recinto>();
        Funcionarios = new List<Funcionario>();
        Visitantes = new List<Visitante>();

        Recinto recinto = new Recinto("SAVANA", 300, Bioma.SAVANA); //Recinto Pre-definido pra DEBUG

        AdicionarRecinto(recinto);
    }

    /*
     *  @Recinto Methods
     */

    public void AdicionarRecinto(Recinto recinto)
    {
        Console.WriteLine($"Adicionando {recinto.Nome} à lista de recintos...");
        Recintos.Add(recinto);
        Console.WriteLine("Recinto adicionado!");
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
        }
        else
        {
            Console.WriteLine("\nTotal de animais: " + totalAnimais);
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
        }

    }

    /*
     *  @Visitante Methods
     */

    public void AdicionarVisitanteZoologico(Visitante visitante)
    {
        Visitantes.Add(visitante);
    }

    public void RemoverVisitanteZoologico(string nomeVisitante)
    {
        foreach (Visitante visitante in Visitantes)
        {
            if (visitante.Nome.ToLower() == nomeVisitante.ToLower())
            {
                Console.WriteLine($"\nRemovendo {visitante.Nome} do cadastro...");
                Visitantes.Remove(visitante);
                Console.WriteLine("Visitante removido!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                break;
            }
        }
    }

    public void ListarVisitantes()
    {
        Console.Clear();
        Console.WriteLine("═════════════════════════════");
        Console.WriteLine("LISTAR VISITANTES CADASTRADOS");
        Console.WriteLine("═════════════════════════════");

        int totalVisitantes = Visitantes.Count;

        if (totalVisitantes == 0)
        {
            Console.WriteLine("\nNão há nenhum visitante cadastrado no Zoológico");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            return;
        }

        foreach (Visitante visitante in Visitantes)
        {
            Console.WriteLine($"\n> VISITANTE <");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($" - Nome: {visitante.Nome} | Idade: {visitante.Idade} anos");
            Console.WriteLine($"   Horário de entrada: {visitante.HorarioEntrada} | Horário de saída: {visitante.HorarioSaida}");
            Console.WriteLine("------------------------------------------");
        }

        Console.WriteLine("\nTotal de visitantes: " + totalVisitantes);
        Console.WriteLine("\nPressione qualquer tecla para continuar...");

    }

    public void RegistrarVisitaZoologico()
    {
        Console.Clear();
        Console.WriteLine("═════════════════════════════");
        Console.WriteLine(" REGISTRAR VISITA ZOOLÓGICO");
        Console.WriteLine("═════════════════════════════");

        Console.Write("\nNome do Visitante: ");
        string nomeVisitante = Console.ReadLine();

        Visitante visitante = Visitantes.FirstOrDefault(v => v.Nome == nomeVisitante) ?? throw new InvalidOperationException("Visitante não encontrado.");
        visitante.HorarioEntrada = DateTime.Now;

        Console.WriteLine($"\nHorário de entrada registrado! ({visitante.HorarioEntrada})");

        Console.Write("\nPretende ficar quantas horas no Zoológico? ");
        int horarioPermanencia = int.Parse(Console.ReadLine());

        visitante.HorarioSaida = visitante.HorarioEntrada?.AddHours(horarioPermanencia);

        Console.WriteLine($"\nHorário de saída registrado! ({visitante.HorarioSaida})");
        Console.WriteLine("\nPressione qualquer tecla para continuar...");

    }

    public void RemoverVisitaZoologico()
    {
        Console.Clear();
        Console.WriteLine("═════════════════════════════");
        Console.WriteLine(" REMOVER VISITA ZOOLÓGICO");
        Console.WriteLine("═════════════════════════════");

        Console.Write("\nNome do Visitante: ");
        string nomeVisitante = Console.ReadLine();

        Visitante visitante = Visitantes.FirstOrDefault(v => v.Nome == nomeVisitante) ?? throw new InvalidOperationException("Visitante não encontrado.");
        visitante.HorarioEntrada = null;
        visitante.HorarioSaida = null;

        Console.WriteLine($"\nHorário de visita (Entrada/Saída) removidos!");
        Console.WriteLine("\nPressione qualquer tecla para continuar...");

    }

    /*
     *  @Extra Methods
     */

    public Dictionary<string, double> CalcularAlimentos()
    {
        Dictionary<string, double> Alimentos = new Dictionary<string, double>();

        Alimentos.Add("Carnes", Recintos.Sum(e => e.Animais.Count(r => r is Mamifero) * 2.5));
        Alimentos.Add("Sementes", Recintos.Sum(e => e.Animais.Count(r => r is Ave) * 1.2));
        Alimentos.Add("Insetos", Recintos.Sum(e => e.Animais.Count(r => r is Reptil) * 0.8));

        return Alimentos;
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
