using LocadoraDeAutomoveis.Dominio.Compartilhado;

namespace LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomoveis
{
    public class GrupoAutomoveis : EntidadeBase
    {
        public string Nome { get; set; }

        public GrupoAutomoveis() {}

        public GrupoAutomoveis(string nome)
        {
            Nome = nome;
        }

        public override List<string> Validar()
        {
            List<string> erros = [];

            if (Nome.Length < 3)
            {
                erros.Add("O nome é obrigatório");
            }

            return erros;
        }
    }
}
