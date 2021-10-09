﻿using DespesaDigital.Code.DAL.dalUsuario;
using DespesaDigital.Code.DTO;
using System.Collections.Generic;

namespace DespesaDigital.Code.BLL
{
    public class bllUsuario
    {
        public static dtoUsuario AutenticaUsuario(string email, string senha)
        {
            var dal = new dalUsuario();
            return dal.AutenticaUsuario(email, senha);
        }

        public static List<dtoUsuario> ListarUsuariosPorStatus(string status)
        {
            var dal = new dalUsuario();
            return dal.ListarUsuariosPorStatus(status);
        }

        public static List<dtoUsuario> ListarUsuariosPorNome(string status, string nome)
        {
            var dal = new dalUsuario();
            return dal.ListarUsuariosPorNome(status, nome);
        }

        public static bool Update(dtoUsuario dto)
        {
            var dal = new dalUsuario();
            return dal.Update(dto);
        }

        public static bool Delete(int codigo)
        {
            var dal = new dalUsuario();
            return dal.Delete(codigo);
        }

        public static dtoUsuario UsuarioPorCodigo(int codigo)
        {
            var dal = new dalUsuario();
            return dal.UsuarioPorCodigo(codigo);
        }

        public static bool UpdateAceitar(int codigo_usuario, int nivel)
        {
            var dal = new dalUsuario();
            return dal.UpdateAceitar(codigo_usuario, nivel);
        }

        public static int NovoUsuario(dtoUsuario dto)
        {
            var dal = new dalUsuario();
            return dal.NovoUsuario(dto);
        }
    }
}