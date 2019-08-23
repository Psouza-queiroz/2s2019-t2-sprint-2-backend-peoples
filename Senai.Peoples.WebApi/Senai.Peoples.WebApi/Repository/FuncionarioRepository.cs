using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repository
{
    public class FuncionarioRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_Peoples;User Id=sa;Pwd=132;";

        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> Funcionarios = new List<FuncionarioDomain>();


                using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT * FROM Funcionarios";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                            Nome = sdr["Nome"].ToString(),
                            Sobrenome = sdr["Sobrenome"].ToString(),
                            DataNascimento = DateTime.Parse(sdr["DataNascimento"].ToString())
                    };
                        Funcionarios.Add(funcionario);    
                    }
                }
            }
            return Funcionarios;
                
        }

        public FuncionarioDomain BuscarPorId(int Id)
        {
            string Query = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE IdFuncionario = @IdFuncionario";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFuncionario", Id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionarioDomain funcionario = new FuncionarioDomain
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                Nome = sdr["Nome"].ToString(),
                                Sobrenome = sdr["Sobrenome"].ToString()
                            };
                            return funcionario;
                        }
                    }
                    return null;
                }
            }
        }
//        public FuncionarioDomain BuscarPorNome(string Nome)
//        {
//            string Query = "SELECT Nome FROM Funcionarios WHERE Nome = @Nome";
//            using (SqlConnection con = new SqlConnection(StringConexao))
//            {
//               con.Open();
//                SqlDataReader sdr;
//
//                using (SqlCommand cmd = new SqlCommand(Query, con))
//              {
//                    cmd.Parameters.AddWithValue("@Nome", Nome);
//                    sdr = cmd.ExecuteReader();
//
//                    if (sdr.HasRows)
//                    {
//                       while (sdr.Read())
//                        {
//                           FuncionarioDomain funcionario = new FuncionarioDomain
//                            {
//                               
//                               Nome = sdr["Nome"].ToString(),
//                                Sobrenome = sdr["Sobrenome"].ToString(),
//                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"])
//                            };
//                            return funcionario;
//
//                        }
//                    }
//                    return null;
//                }
//            }
//        }

        public void Cadastrar(FuncionarioDomain funcionarioDomain)
        {
            string Query = "INSERT INTO Funcionarios (Nome, Sobrenome, DataNascimento) VALUES (@Nome,@Sobrenome,@DataNascimento)";


            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionarioDomain.Sobrenome);
                cmd.Parameters.AddWithValue("@DataNascimento", funcionarioDomain.DataNascimento);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Atualizar (FuncionarioDomain funcionarioDomain)
        {

            string Query = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome, DataNascimento = @DataNascimento WHERE IdFuncionario = @Id";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionarioDomain.Sobrenome);
                cmd.Parameters.AddWithValue("@Id", funcionarioDomain.IdFuncionario);
                cmd.Parameters.AddWithValue("@DataNascimento", funcionarioDomain.DataNascimento);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public void Deletar(int Id)
        {

            String Query = "DELETE FROM Funcionarios WHERE IdFuncionario = @Id";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }
        }

    }
}
