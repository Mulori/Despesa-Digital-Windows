﻿using DespesaDigital.Code.DAL.dalSolicitacaoCompra;
using DespesaDigital.Code.DTO.dtoSolicitacaoCompra;
using System;
using System.Collections.Generic;
using System.Data;

namespace DespesaDigital.Code.BLL.bllSolicitacaoCompra
{
    public class bllSolicitacaoCompra
    {
        public static List<dtoSolicitacaoCompra> ListarTodosProdutosPorStatus(string status)
        {
            var dal = new dalSolicitacaoCompra();
            return dal.ListarTodasSolicitacaoPorStatus(status);
        }

        public static List<dtoSolicitacaoCompra> ListarTodasSolicitacaoPorStatusSetor(string status, int codigo_setor)
        {
            var dal = new dalSolicitacaoCompra();
            return dal.ListarTodasSolicitacaoPorStatusSetor(status, codigo_setor);
        }

        public static List<dtoSolicitacaoCompra> ListarTodasSolicitacaoPorStatusData(string status, DateTime inicial, DateTime final)
        {
            var dal = new dalSolicitacaoCompra();
            return dal.ListarTodasSolicitacaoPorStatusData(status, inicial, final);
        }

        public static dtoSolicitacaoCompra SolicitacaoPorCodigo(long codigo)
        {
            var dal = new dalSolicitacaoCompra();
            return dal.SolicitacaoPorCodigo(codigo);
        }

        public static bool UpdateStatus(long codigo_solicitacao, string status)
        {
            var dal = new dalSolicitacaoCompra();
            return dal.UpdateStatus(codigo_solicitacao, status);
        }

        public static bool UsuarioAprovouRejeitou(long codigo_solicitacao, int codigo_gestor)
        {
            var dal = new dalSolicitacaoCompra();
            return dal.UsuarioAprovouRejeitou(codigo_solicitacao, codigo_gestor);
        }

        public static DataSet RelSolicitacao(DateTime inicio, DateTime fim, int codigo_setor, int codigo_usuario)
        {
            var dal = new dalSolicitacaoCompra();
            return dal.RelSolicitacao(inicio, fim, codigo_setor, codigo_usuario);
        }
    }
}
