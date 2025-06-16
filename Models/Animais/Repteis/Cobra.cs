using System;
using ZoologicoManager.Enums;
using ZoologicoManager.Services;
namespace ZoologicoManager.Models.Animais.Repteis;

public class Cobra : Reptil, IAnimalVeterinavel
{
	public bool Venenosa { get; }
	public Cobra(int id, string nome, int idade, Alimentacao alimentacao, bool trocaDePele, bool venenosa) : base(id, nome, idade, alimentacao, trocaDePele)
    {
        Venenosa = venenosa;
	}

    public void PrepararParaExame() => Console.WriteLine("Amarrando para exame");

    public void ReceberVacina(Vacina tipoVacina) => Console.WriteLine($"Aplicando a vacina de {tipoVacina} no {Nome}");
}
