﻿using controle_financeiro_api.Model;
using controle_financeiro_api.Model.DTO.Request;
using controle_financeiro_api.Model.DTO.Response;
using controle_financeiro_api.Model.Enum;

namespace controle_financeiro_api.Service
{
    public interface IDespesaService
    {
        Task<bool> Criar(DespesaCriarRequest request);
        Task<bool> ValidarSaldo(DespesaCriarRequest request);
        Task<ReceitaDespesaResponse> Listar(int usuarioId, Mes mes);
    }
}
