using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraDeAutomoveis.Testes.Unidade
{
    [TestClass]
    public class GrupoAutomoveisTests
    {
        [TestMethod]
        public void Deve_Criar_Instancia_Valida()
        {
            var grupo = new GrupoAutomoveis("SUV");

            grupo.Validar();
        }
    }
}