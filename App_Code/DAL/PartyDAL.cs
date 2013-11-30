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




public class PartyDAL
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rateMyMPConnectionString"].ConnectionString);
    SqlCommand cmd;
    SqlDataAdapter dap;
    string query;


    public bool partyInsert(partyBO PartyBO)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand("partyInsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@party", PartyBO.partyName);
            cmd.Parameters.AddWithValue("@abbreviation", PartyBO.abbreviation);
            cmd.Parameters.AddWithValue("@totalMember", PartyBO.totalMember);
            cmd.Parameters.AddWithValue("@countryId", PartyBO.countryId);
            SqlParameter message = cmd.Parameters.Add("@res",SqlDbType.Bit);
            message.Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            return(bool.Parse(message.Value.ToString ()));


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

            query = "PARTY_FETCHING";
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



    public DataTable getData(partyBO PartyBO)
    {
        try
        {

            query = "fetchParty";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@countryId", PartyBO.countryId);
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

    public void partyUpdate( partyBO PartyBO)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand("partyUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@partyId", PartyBO.partyId);
            cmd.Parameters.AddWithValue("@party", PartyBO.partyName);
            cmd.Parameters.AddWithValue("@abbreviation", PartyBO.abbreviation);
            cmd.Parameters.AddWithValue("@totalMember", PartyBO.totalMember);
            cmd.Parameters.AddWithValue("@countryId", PartyBO.countryId);
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
