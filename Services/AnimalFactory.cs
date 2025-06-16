using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoologicoManager.Models.Animais;
using ZoologicoManager.Models.Animais.Aves;
using ZoologicoManager.Models.Animais.Mamiferos;
using ZoologicoManager.Models.Animais.Repteis;

namespace ZoologicoManager.Services
{
    public class AnimalFactory
    {
        public static Animal CriarAnimal(int id, string nome, int idade, Alimentacao alimentacao, string tipoAnimal, Dictionary<string, object> caracteristicas)
        {
            return tipoAnimal.ToLower() switch
            {
                "aguia" => new Aguia(id, nome, idade, alimentacao, (double)caracteristicas["envergaduraAsa"], (bool)caracteristicas["visaoAgucada"]),

                "leao" => new Leao(id, nome, idade, alimentacao, (int)caracteristicas["gestacao"], (bool)caracteristicas["melena"]),

                "cobra" => new Cobra(id, nome, idade, alimentacao, (bool)caracteristicas["trocaDePele"], (bool)caracteristicas["venenosa"]),

                _ => throw new ArgumentException("Tipo de animal não suportado.")
            };
        }
    }
}
