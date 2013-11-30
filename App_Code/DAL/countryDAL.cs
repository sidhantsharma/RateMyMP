using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for countryDAL
/// </summary>
public class countryDAL
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rateMyMPConnectionString"].ConnectionString);
    SqlDataAdapter adap;
    SqlCommand cmd;
    string query;

    public bool countryInsert(countryBO countryBO)
    {
        try
        {
            query = "countryInsert";
            cmd = new SqlCommand("countryInsert", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@countryName",countryBO.country);
            SqlParameter message = cmd.Parameters.Add("@res", SqlDbType.Bit);
            message.Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            return (bool.Parse(message.Value.ToString()));           
        }
        catch
        {
            throw;
            
        }
        finally 
        {
            con.Close();
        }

    }

    public DataTable load_country()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            adap = new SqlDataAdapter("selectCountry", con);
            adap.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            adap.Fill(ds, "country");
            adap.Dispose();
            return ds.Tables["country"];
        }
        catch
        {
            throw;
        }

        finally
        {
            con.Close();
        }
    }





    

}