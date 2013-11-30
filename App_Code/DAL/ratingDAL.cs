using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for ratingDAL
/// </summary>
public class ratingDAL
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rateMyMPConnectionString"].ConnectionString);
    SqlCommand cmd;
    SqlDataAdapter dap;
    string query;

	public ratingDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable getRating(Int64 mpId, Int16 paramId, Int64 guId, Int16 rating)
    {
        try
        {

            query = "RATING_POSTING";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@paramId",paramId);
            dap.SelectCommand.Parameters.AddWithValue("@mpId",mpId);
            dap.SelectCommand.Parameters.AddWithValue("guId",guId);
            dap.SelectCommand.Parameters.AddWithValue("rating",rating);
            DataSet ds = new DataSet();
            dap.Fill(ds, "temp");
            dap.Dispose();
            return ds.Tables["temp"];
        }
        catch
        {
            throw;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
    }
}