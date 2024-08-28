using FluentResults;
using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;

namespace LocadoraDeAutomoveis.Aplicacao.Serviços
{
    public class AutomovelService
    {
        private readonly IRepositorioAutomovel repositorioAutomovel;

        public AutomovelService(IRepositorioAutomovel repositorioAutomovel)
        {
            this.repositorioAutomovel = repositorioAutomovel;
        }

        public Result<Automovel> Inserir(Automovel automovel)
        {
			repositorioAutomovel.Inserir(automovel);

	        return Result.Ok(automovel);
        }

        public Result<Automovel> Editar(Automovel automovelAtualizado)
        {
	        var automovel = repositorioAutomovel.SelecionarPorId(automovelAtualizado.Id);

	        if (automovel is null)
		        return Result.Fail("O veículo não foi encontrado!");

	        automovel.Modelo = automovelAtualizado.Modelo;
	        automovel.Marca = automovelAtualizado.Marca;
	        automovel.TipoCombustivel = automovelAtualizado.TipoCombustivel;
	        automovel.CapacidadeTanque = automovelAtualizado.CapacidadeTanque;
	        automovel.GrupoAutomoveisId = automovelAtualizado.GrupoAutomoveisId;

			repositorioAutomovel.Editar(automovel);

	        return Result.Ok(automovel);
        }

        public Result<Automovel> Excluir(int automovelId)
        {
	        var veiculo = repositorioAutomovel.SelecionarPorId(automovelId);

	        if (veiculo is null)
		        return Result.Fail("O veículo não foi encontrado!");

	        repositorioAutomovel.Excluir(veiculo);

	        return Result.Ok(veiculo);
        }

        public Result<Automovel> SelecionarPorId(int automovelId)
        {
	        var veiculo = repositorioAutomovel.SelecionarPorId(automovelId);

	        if (veiculo is null)
		        return Result.Fail("O veículo não foi encontrado!");

	        return Result.Ok(veiculo);
        }

        public Result<List<Automovel>> SelecionarTodos()
        {
	        var veiculos = repositorioAutomovel.SelecionarTodos();

	        return Result.Ok(veiculos);
        }
	}
}
