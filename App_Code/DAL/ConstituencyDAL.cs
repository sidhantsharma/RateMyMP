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




public class ConstituencyDAL
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rateMyMPConnectionString"].ConnectionString);
    SqlCommand cmd;
    SqlDataAdapter dap;
    string query;


    public bool checkMpExistOrNot(Int16 constituencyId)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "checkMpExistOrNot";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@constituencyId", constituencyId);
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
    public bool constituencyInsert(constituencyBO constituencyB0)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "constituencyInsert";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@stateId", constituencyB0.StateId);
            cmd.Parameters.AddWithValue("@constituency", constituencyB0.constituency);
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
    public DataTable getData()
    {
        try
        {
            query = "CONSTITUENCY_FETCHING";
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
        {  if(con.State == ConnectionState.Open)
            con.Close();
        }
    }
    public DataTable getData(Int16 stateId)
    {
        try
        {

            query = "CONSTITUENCY_FETCHING";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@stateId",stateId);
            DataSet ds = new DataSet();
            dap.Fill(ds, "temp");
            con.Close();
            dap.Dispose();
            return ds.Tables["temp"];
        }
        catch
        {
            throw;
        }
        finally
        {  if(con.State == ConnectionState.Open)
            con.Close();
        }
    }




    public void updateConstituency(constituencyBO constituencyBO)
    {
        try
        {

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "constituencyUpdate";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@stateId", constituencyBO.StateId);
            cmd.Parameters.AddWithValue("@constituencyId", constituencyBO.constituencyId);
            cmd.Parameters.AddWithValue("@constituency", constituencyBO.constituency);
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
