using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repository
{
    public class AutoresRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_BookStore ;User Id=sa;Pwd=132;";

        public List<AutoresDomain> Listar()
        {
            List<AutoresDomain> Generos = new List<AutoresDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT * FROM Generos";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        AutoresDomain generos = new AutoresDomain
                        {
                            IdAutores = Convert.ToInt32(sdr["IdAutores"]),
                            Nome = sdr["Nome"].ToString(),
                            //Ativo
                            DataNascimento = DateTime.Parse(sdr["DataNascimento"].ToString())
                        };
                        Generos.Add(generos);
                    }
                }

            }
            return Generos;
        }
        public void Cadastrar(AutoresDomain AutoresDomain)
        {
            string Query = "INSERT INTO Autores (Nome,Email,ativo,DataNascimento) VALUES (@Nome,@Email,@Ativo,@DataNascimento) ";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("Nome", AutoresDomain.Nome);
                cmd.Parameters.AddWithValue("Email", AutoresDomain.Email);
                cmd.Parameters.AddWithValue("ativo", AutoresDomain.Ativo);
                cmd.Parameters.AddWithValue("DataNascimento", AutoresDomain.DataNascimento);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
