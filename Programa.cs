using System;
using ZoologicoManager.Models.Animais;
using ZoologicoManager.Models.Animais.Mamiferos;
using ZoologicoManager.Models.Recintos;
using ZoologicoManager.Services;
using ZoologicoManager.UI;
namespace ZoologicoManager;
public class Programa
{
    public static bool IsRunning { get; set; } = true;
	public static void Main(string[] args)
	{
        /*
         * Instanciar Zoológico e suas dependências
         * e INICIAR o Menu!
         */

        Zoologico zoo = new Zoologico();
        GerenciadorMenu.MostrarMenu(zoo);
    }

}
