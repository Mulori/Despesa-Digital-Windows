using DespesaDigital.Config;
using Npgsql;
using System.Data;

namespace DespesaDigital.Code.DAL.dalConexao
{
    public class dalConexao
    {
        public static NpgsqlConnection cnn { get; set; }

        public bool Conectar()
        {
            try
            {
                //170.231.105.127

                var server_net = ReadConfigServerNet.GetConfigServerNET();
                cnn = new NpgsqlConnection();
                cnn.ConnectionString = $"Server={server_net.IP};Port=8077;User Id=postgres;Password=190123;Database=despesadigital;CommandTimeout=500;";

                cnn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Desconectar()
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
                return true;
            }

            return false;
        }
    }
}
