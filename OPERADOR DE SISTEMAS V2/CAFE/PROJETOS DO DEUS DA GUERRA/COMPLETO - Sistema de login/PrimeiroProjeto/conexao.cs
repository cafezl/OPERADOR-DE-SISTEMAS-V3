using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PrimeiroProjeto
{
    
    public static class Conexao
    {
        
        private static string StringConexao =
            "Server=localhost;" +
            "database=primeiroprojeto;" +
            "uid=root;pwd=;";

        public static MySqlConnection Abrir()
        {
            MySqlConnection conexao = new MySqlConnection(StringConexao);
            try
            {
                conexao.Open();
                return conexao;
            }
            catch
            {
                conexao.Dispose();
                throw;
            }
        }
    }
}
