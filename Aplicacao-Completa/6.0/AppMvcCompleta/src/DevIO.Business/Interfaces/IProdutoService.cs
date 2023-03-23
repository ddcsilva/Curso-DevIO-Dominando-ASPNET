using DevIO.Business.Models;

namespace DevIO.Business.Intefaces;

public interface IProdutoService
{
    Task Adicionar(Produto produto);
    Task Atualizar(Produto produto);
    Task Remover(Guid id);
}