using System;
using ZoologicoManager.Enums;
using ZoologicoManager.Services;

namespace ZoologicoManager.Models.Animais.Aves;

public class Aguia : Ave, IAnimalVeterinavel
{
	public bool VisaoAgucada { get; }
	public Aguia(int id, string nome, int idade, Alimentacao alimentacao, double envergaduraAsa, bool visaoAgucada) : base(id, nome, idade, alimentacao, envergaduraAsa)
	{
        VisaoAgucada = visaoAgucada;
	}

    public void PrepararParaExame() => Console.WriteLine("Pousando para exame");

	public void ReceberVacina(Vacina tipoVacina) => Console.WriteLine($"Aplicando a vacina de {tipoVacina} no {Nome}");
}
