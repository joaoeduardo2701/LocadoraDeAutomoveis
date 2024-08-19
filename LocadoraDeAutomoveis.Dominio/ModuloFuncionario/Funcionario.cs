using LocadoraDeAutomoveis.Dominio.Compartilhado;

namespace LocadoraDeAutomoveis.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase
    {
        public string Nome { get; set; }
        public DateTime DataAdmissao { get; set; }
        public double Salario { get; set; }

        public Funcionario(string nome, DateTime dataAdmissao, double salario)
        {
            Nome = nome;
            DataAdmissao = dataAdmissao;
            Salario = salario;
        }
    }
}
 