using System;

namespace ZoologicoManager.Models.Animais;

public abstract class Animal
{
	public int Id {	get; set; }
	public string Nome {  get; set; }
	public int Idade {  get; set; }

	public Alimentacao Alimentacao { get; }

	protected Animal(int id, string nome, int idade, Alimentacao alimentacao)
	{
        Id = id;
        Nome = nome;
        Idade = idade;
        Alimentacao = alimentacao;
	}

	public abstract void EmitirSom();
	public abstract void Alimentar();
    public virtual void Dormir()
    {
        Console.WriteLine($"{Nome} está dormindo...");
    }
}
