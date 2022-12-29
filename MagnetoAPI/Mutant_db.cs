
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNet.SignalR.Json;
using DocumentFormat.OpenXml.Wordprocessing;

namespace MagnetoAPI
{
    public class Mutant_db
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-14RTD30;Initial Catalog=Mutans_BD;Integrated Security=True");

        //Add 
        public string DnaAdd(Mutant mut, out string msg)
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(mut);
                SqlCommand com = new SqlCommand("Proc_Add_MutantDNA", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@dna", mut.dna.ToString());
                con.Open();
                com.ExecuteNonQuery();
                con.Close();


                msg = "SUCCESS";

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return msg;
        }


        //Get 
        public DataSet MutantGet(Mutant mut, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("Proc_Get_MutantDNA", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    msg = "SUCCESS";
                }
                else
                {
                    msg = "La consulta no arrojó ningún resultado";
                }
                

            }
            catch (Exception ex)
            {
               msg= ex.Message;
            }
            return ds;
        }   
            
    }
}
