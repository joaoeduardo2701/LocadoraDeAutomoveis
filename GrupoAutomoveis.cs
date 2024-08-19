using LocadoraDeAutomoveis.Dominio.Compartilhado;
namespace LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomoveis

public class GrupoAutomoveis : EntidadeBase
{
	public string Nome { get; set; }

	public GrupoAutomoveis(string nome)
	{
		Nome = nome;
	}
}
