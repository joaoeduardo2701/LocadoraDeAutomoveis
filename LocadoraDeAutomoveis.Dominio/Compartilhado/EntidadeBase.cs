namespace LocadoraDeAutomoveis.Dominio.Compartilhado
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }
        public abstract List<string> Validar();
	}
}
