using System;

namespace ZoologicoManager.Models.Animais;

public class Reptil : Animal
{
	public bool TrocaDePele {  get; set; }

	public Reptil(int id, string nome, int idade, Alimentacao alimentacao, bool trocaDePele) : base(id, nome, idade, alimentacao)
	{
        TrocaDePele = trocaDePele;
	}

    public override void EmitirSom() => Console.WriteLine("Ssss...");

    public override void Alimentar() => Console.WriteLine("Comendo inseto...");
}
