using System;
using ZoologicoManager.Enums;
namespace ZoologicoManager.Services;

public interface IAnimalVeterinavel
{
	public void PrepararParaExame();
	public void ReceberVacina(Vacina tipoVacina);
}
