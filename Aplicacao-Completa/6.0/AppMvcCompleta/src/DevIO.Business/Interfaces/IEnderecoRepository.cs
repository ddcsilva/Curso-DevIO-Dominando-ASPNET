﻿using DevIO.Business.Models;

namespace DevIO.Business.Interfaces;

public interface IEnderecoRepository : IRepository<Endereco>
{
    Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
}
