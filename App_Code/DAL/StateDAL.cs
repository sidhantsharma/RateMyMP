using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;


public class StateDAL
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rateMyMPConnectionString"].ConnectionString);
    SqlCommand cmd;
    SqlDataAdapter dap;
    string query;

    public bool stateInsert(stateBO StateBO)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd = new SqlCommand("stateInsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@stateName", StateBO.state);
            cmd.Parameters.AddWithValue("@noOfConstituency", StateBO.noOfConstituency);
            cmd.Parameters.AddWithValue("@countryId", StateBO.countryId);
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
    public DataTable getData()
    {
        try
        {

            query = "STATE_FETCHING";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
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
        {   if(con.State == ConnectionState.Open)
            con.Close();
        }
    }
    public void updateState(stateBO StateBO)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd = new SqlCommand("stateUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@countryId", StateBO.countryId);
            cmd.Parameters.AddWithValue("@stateId", StateBO.stateId);
            cmd.Parameters.AddWithValue("@stateName", StateBO.state);
            cmd.ExecuteNonQuery();
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
