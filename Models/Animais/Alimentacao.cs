using System;
namespace ZoologicoManager.Models.Animais;

public class Alimentacao
{
	public string Tipo { get; private set; }
	private int Frequencia { get; set; }
	private double Quantidade { get; set; }
	public Alimentacao(string tipo, int frequencia, double quantidade)
	{
        Tipo = tipo;
        Frequencia = frequencia;
        Quantidade = quantidade;
	}
}
