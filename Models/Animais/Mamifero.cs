using System;

namespace ZoologicoManager.Models.Animais;

public class Mamifero : Animal
{
	public int Gestacao { get; set; }
	public Mamifero(int id, string nome, int idade, Alimentacao alimentacao, int gestacao) : base(id, nome, idade, alimentacao)
	{
        Gestacao = gestacao;
	}

    public override void EmitirSom() => Console.WriteLine("Roar-Roar");

	public override void Alimentar() => Console.WriteLine("Comendo Carne...");
}
