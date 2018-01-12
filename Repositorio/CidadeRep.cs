using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProjetoCidades.Models;

namespace ProjetoCidades.Repositorio
{
    public class CidadeRep
    {
        string connectionString = @"Data source=.\SqlExpress;Initial Catalog=ProjetoCidades;uid=sa;pwd=senai@123";

        public List<Cidade> Listar(){
            List<Cidade> lstCidades = new List<Cidade>();

            SqlConnection con = new SqlConnection(connectionString);

            string SqlQuery = "Select * from Cidades";

            SqlCommand cmd = new SqlCommand(SqlQuery,con);

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            
            while(sdr.Read()){
                Cidade cidade = new Cidade();

                cidade.Id = Convert.ToInt16(sdr["Id"]);
                cidade.Nome = sdr["Nome"].ToString();
                cidade.Estado = sdr ["Estado"].ToString();
                cidade.Habitantes = Convert.ToInt32(sdr ["Habitantes"]);

                lstCidades.Add(cidade);
            }

            con.Close();

            return lstCidades;

        }

        public void Cadastrar (Cidade cidade){
            SqlConnection con = new SqlConnection (connectionString);

            string SqlQuery="insert into Cidades (Nome,Estado,Habitantes) values('"+ cidade.Nome +"','"+cidade.Estado + "',"+cidade.Habitantes+")";    

            SqlCommand cmd = new SqlCommand(SqlQuery,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void Editar (Cidade cidade){
            SqlConnection con = new SqlConnection (connectionString);
            string msg;
            
            try{
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Update Cidades set nome = @n, estado =@e, habitantes = @h where id = @id";
                cmd.Parameters.AddWithValue("@n", cidade.Nome);
                cmd.Parameters.AddWithValue("@e", cidade.Estado);
                cmd.Parameters.AddWithValue("@h", cidade.Habitantes);
                cmd.Parameters.AddWithValue("@id", cidade.Id);
                //string SqlQuery="update into Cidades (Nome,Estado,Habitantes) values('"+ cidade.Nome +"','"+cidade.Estado + "',"+cidade.Habitantes+")";    
                //SqlCommand cmd = new SqlCommand(SqlQuery,con);
                con.Open();
                //cmd.ExecuteNonQuery();
                //con.Close();
                int r = cmd.ExecuteNonQuery();

                if(r > 0)
                    msg = "Atualização Efetuada";
                else
                    msg = "Não foi possível atualizar";
                
                cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar atualizar dados " + se.Message);
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro inesperado " + e.Message);
                throw;
            }
        }
    public string Excluir (int id){
            SqlConnection con = new SqlConnection (connectionString);
            string msg;
            
            try{
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Cidades WHERE id = @id";
            
                cmd.Parameters.AddWithValue("@id", id);
                int r = cmd.ExecuteNonQuery();

                if(r > 0)
                    msg = "Cidade excluída";
                else
                    msg = "Não foi possível excluir";
                
                cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar atualizar dados " + se.Message);
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro inesperado " + e.Message);
                throw;
            }
            return msg;
        }}


}