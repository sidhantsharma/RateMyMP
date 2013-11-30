using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for districtDAL
/// </summary>
public class districtDAL
{
	public districtDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rateMyMPConnectionString"].ConnectionString);
    SqlCommand cmd;
    SqlDataAdapter dap;
    string query;
    public bool districtInsert(districtBO districtBO)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "districtInsert";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@stateId", districtBO.stateId);
            cmd.Parameters.AddWithValue("@districtName", districtBO.districtName);
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
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }



    public void districtUpdate(districtBO districtBO)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "districtUpdate";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@stateId", districtBO.stateId);
            cmd.Parameters.AddWithValue("@districtId", districtBO.districtId);
            cmd.Parameters.AddWithValue("@districtName", districtBO.districtName);
            cmd.ExecuteNonQuery();

        }
        catch
        {
            throw;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }


}