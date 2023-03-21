using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository;

public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
{
    public FornecedorRepository(MeuDbContext context) : base(context) { }

    public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
    {
        return await _context.Fornecedores.AsNoTracking()
            .Include(f => f.Endereco)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
    {
        return await _context.Fornecedores.AsNoTracking()
            .Include(f => f.Produtos)
            .Include(f => f.Endereco)
            .FirstOrDefaultAsync(f => f.Id == id);
    }
}
