using System;

namespace ZoologicoManager.Models.Animais;

public class Ave : Animal
{
	public double EnvergaduraAsa { get; set; }

	public Ave(int id, string nome, int idade, Alimentacao alimentacao, double envergaduraAsa) : base(id, nome, idade, alimentacao)
	{
        EnvergaduraAsa = envergaduraAsa;
	}

    public override void EmitirSom() => Console.WriteLine("Piu-Piu");

	public override void Alimentar() => Console.WriteLine("Comendo sementes...");
}
