﻿using controle_financeiro_api.Models;

namespace controle_financeiro_api.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Obter(int id);
        Task<bool> Criar(Usuario usuario);
        Task<bool> Alterar(Usuario usuario);
    }
}