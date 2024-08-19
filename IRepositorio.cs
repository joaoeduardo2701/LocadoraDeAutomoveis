﻿namespace LocadoraDeAutomoveis.Dominio.Compartilhado;

public interface IRepositorio<TEntidade> where TEntidade : EntidadeBase
{
    void Inserir(TEntidade entidade);
    void Editar(TEntidade entidadeAtualizada);
    void Excluir(TEntidade entidadeParaExcluir);
    TEntidade? SelecionarPorId(int idSelecionado);
    List<TEntidade> SelecionarTodos();
}
