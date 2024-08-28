using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraDeAutomoveis.Testes.Unidade.ModuloGrupoAutomoveis
{
    [TestClass]
    [TestCategory("Unidade")]
    public class GrupoAutomoveisTests
    {
        [TestMethod]
        public void Deve_Criar_Instancia_Valida()
        {
            var grupo = new GrupoAutomoveis("SUV");

            var erros = grupo.Validar();

            Assert.AreEqual(0, erros.Count);
        }

        public void Deve_Criar_Instancia_Com_Erro()
        {
            var grupo = new GrupoAutomoveis("SU");

            var erros = grupo.Validar();

            List<string> errosEsperados = ["O nome é obrigatório"];

            Assert.AreNotEqual(0, erros.Count);

            CollectionAssert.AreEqual(errosEsperados, erros);
        }
    }
}