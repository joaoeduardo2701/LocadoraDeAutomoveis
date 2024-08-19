using LocadoraDeAutomoveis.Dominio.Compartilhado;
namespace LocadoraDeAutomoveis.Dominio.ModuloFuncionario

public class Funcionario : EntidadeBase
{
    public string Nome { get; set; }
    public DateTime DataAdmissao { get; set; }
    public float Salario { get; set; }
    
    public Funcionario()
    {
         
    }

    public Funcionario(string nome, DateTime dataAdmissao, float salario)
    {
        Nome = nome;
        DataAdmissao = dataAdmissao;
        Salario = salario;
    }
}
