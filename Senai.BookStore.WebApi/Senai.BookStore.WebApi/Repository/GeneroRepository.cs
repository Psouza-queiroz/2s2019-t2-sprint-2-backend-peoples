using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repository
{
    public class GeneroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_BookStore ;User Id=sa;Pwd=132;";

        public List<GenerosDomain> Listar()
        {
           List<GenerosDomain> Generos = new List<GenerosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdGenero, Descricao FROM Generos";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while(sdr.Read())
                    {
                        GenerosDomain generos = new GenerosDomain
                        {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Descricao = sdr["Descricao"].ToString()
                        };
                        Generos.Add(generos);
                    }
                }
            
            }
            return Generos;
        }
           public void Cadastrar (GenerosDomain generosDomain)
        {
            string Query = "INSERT INTO Generos (Descricao) VALUES (@Descricao)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("Descricao", generosDomain.Descricao);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
