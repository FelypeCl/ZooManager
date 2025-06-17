using System;
namespace ZoologicoManager.Models.Pessoas;

public class Visitante
{
	public string Nome { get; set; }
	public int Idade { get; set; }
	public DateTime? HorarioEntrada { get; set; }
	public DateTime? HorarioSaida { get; set; }
	public Visitante(string nome, int idade)
	{
        Nome = nome;
        Idade = idade;
	}
}
