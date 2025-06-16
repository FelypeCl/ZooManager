using System;
using ZoologicoManager.Enums;
using ZoologicoManager.Services;

namespace ZoologicoManager.Models.Animais.Mamiferos;

public class Leao : Mamifero, IAnimalVeterinavel
{
	public bool Melena { get; }
	public Leao(int id, string nome, int idade, Alimentacao alimentacao, int gestacao, bool melena) : base(id, nome, idade, alimentacao, gestacao)
	{
        Melena = melena;
	}

    public void PrepararParaExame() => Console.WriteLine("Deitando para exame");

    public void ReceberVacina(Vacina tipoVacina) => Console.WriteLine($"Aplicando a vacina de {tipoVacina} no {Nome}");
}
