using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProjetoCidades.Models;

namespace ProjetoCidades_master.Repositorio
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
    }
}