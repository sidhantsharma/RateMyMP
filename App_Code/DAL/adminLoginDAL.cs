using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for adminLoginDAL
/// </summary>
public class adminLoginDAL
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rateMyMPConnectionString"].ConnectionString);
    SqlCommand cmd;
    SqlDataAdapter dap;
    string query;
	public adminLoginDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool adminLoginCheck(adminLoginBO adminLoginBO)
    {
        try
        {
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            query = "adminLoginCheck";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@adminId", adminLoginBO.adminId);
            cmd.Parameters.AddWithValue("@password", adminLoginBO.password);
            SqlParameter result = cmd.Parameters.Add("@res", SqlDbType.Bit);
            result.Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            return (bool.Parse(result.Value.ToString()));
        }
        catch
        {
            throw;
        }
        finally
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
        }
    }

}