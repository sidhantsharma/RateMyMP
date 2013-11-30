using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class mpDetailsDAL
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["rateMyMPConnectionString"].ConnectionString);
    SqlCommand cmd;
    SqlDataAdapter dap;
    string query;
	public mpDetailsDAL()
	{
        //constructor
	}

    public bool updateMpDetails(userMasterBO userMasterBO, mpDetailsBO mpDetailsBO)
    {
        try
        {
           
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "updateMpDetails";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@guId", userMasterBO.guid);
            cmd.Parameters.AddWithValue("@email", userMasterBO.email);
            cmd.Parameters.AddWithValue("@password", userMasterBO.password);
            cmd.Parameters.AddWithValue("@firstName", userMasterBO.firstName);
            cmd.Parameters.AddWithValue("@middleName", userMasterBO.middleName);
            cmd.Parameters.AddWithValue("@lastName", userMasterBO.lastName);
            cmd.Parameters.AddWithValue("@socialNetwork", userMasterBO.socialNetwork);
            cmd.Parameters.AddWithValue("@snTypeId", userMasterBO.snTypeId);
            cmd.Parameters.AddWithValue("@status", userMasterBO.status);
            cmd.Parameters.AddWithValue("@profilepic", userMasterBO.profilePicPath);

            // now the part of mpdetails table
            cmd.Parameters.AddWithValue("@mpId", mpDetailsBO.mpId);
            cmd.Parameters.AddWithValue("@countryId", mpDetailsBO.countryId);
            cmd.Parameters.AddWithValue("@constituencyId", mpDetailsBO.constituencyId);
            cmd.Parameters.AddWithValue("@electedYear", mpDetailsBO.electedYear);
            cmd.Parameters.AddWithValue("@partyId", mpDetailsBO.partyId);
            cmd.Parameters.AddWithValue("@phone", mpDetailsBO.phone);
            cmd.Parameters.AddWithValue("@mobile", mpDetailsBO.mobile);
            cmd.Parameters.AddWithValue("@qualification", mpDetailsBO.qualification);
            cmd.Parameters.AddWithValue("@professioin", mpDetailsBO.profession);
            cmd.Parameters.AddWithValue("@permanentAddress", mpDetailsBO.permenantAddress);
            cmd.Parameters.AddWithValue("@permanentDistrictId", mpDetailsBO.permanentDistrict);
            cmd.Parameters.AddWithValue("@permanentStateId", mpDetailsBO.permanentState);
            cmd.Parameters.AddWithValue("@currentAddress", mpDetailsBO.currentAddress);
            cmd.Parameters.AddWithValue("@currentDistrictId", mpDetailsBO.currentDistrictId);
            cmd.Parameters.AddWithValue("@currentStateId", mpDetailsBO.currentStateId);
            SqlParameter message = cmd.Parameters.Add("@message", SqlDbType.Bit);
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
    public DataTable getMpDetails(Int64 mpId)
    {
        try
        {
            query = "getMpDetailsForUpdate";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@mpId", mpId);
            DataSet ds = new DataSet();
            dap.Fill(ds, "tblMpDetails");
            dap.Dispose();
            return ds.Tables["tblMpDetails"];

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
    public DataTable fetchMPBasedOnStateorConstituency(countryBO CountryBO, stateBO StateBO, constituencyBO constituencyBO)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            dap = new SqlDataAdapter("fetchMPBasedOnStateorConstituency", con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@countryId", CountryBO.countryId);
            dap.SelectCommand.Parameters.AddWithValue("@stateId", StateBO.stateId);
            dap.SelectCommand.Parameters.AddWithValue("@constituencyId", constituencyBO.constituencyId);
            DataSet ds = new DataSet();
            dap.Fill(ds, "tblMpDetails");
            dap.Dispose();
            return ds.Tables["tblMpDetails"];
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
    public DataTable getData(Int16 constituencyId)
    {
        try
        {
            query = "MPDETAILS_FETCHING";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@constituencyId", constituencyId);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
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
    public bool saveMpDetails(userMasterBO userMasterBO,mpDetailsBO mpDetailsBO)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "saveMpDetails";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", userMasterBO.email);
            cmd.Parameters.AddWithValue("@password", userMasterBO.password);
            cmd.Parameters.AddWithValue("@firstName", userMasterBO.firstName);
            cmd.Parameters.AddWithValue("@middleName", userMasterBO.middleName);
            cmd.Parameters.AddWithValue("@lastName", userMasterBO.lastName);
            cmd.Parameters.AddWithValue("@socialNetwork", userMasterBO.socialNetwork);
            cmd.Parameters.AddWithValue("@snTypeId", userMasterBO.snTypeId);
            cmd.Parameters.AddWithValue("@status", userMasterBO.status);
            cmd.Parameters.AddWithValue("@profilepic", userMasterBO.profilePicPath);
         
            // now the part of mpdetails table
            cmd.Parameters.AddWithValue("@countryId", mpDetailsBO.countryId);
            cmd.Parameters.AddWithValue("@constituencyId", mpDetailsBO.constituencyId);
            cmd.Parameters.AddWithValue("@electedYear", mpDetailsBO.electedYear);
            cmd.Parameters.AddWithValue("@partyId", mpDetailsBO.partyId);
            cmd.Parameters.AddWithValue("@phone", mpDetailsBO.phone);
            cmd.Parameters.AddWithValue("@mobile", mpDetailsBO.mobile);
            cmd.Parameters.AddWithValue("@qualification", mpDetailsBO.qualification);
            cmd.Parameters.AddWithValue("@professioin", mpDetailsBO.profession);
            cmd.Parameters.AddWithValue("@permanentAddress", mpDetailsBO.permenantAddress);
            cmd.Parameters.AddWithValue("@permanentDistrictId", mpDetailsBO.permanentDistrict);
            cmd.Parameters.AddWithValue("@permanentStateId", mpDetailsBO.permanentState);
            cmd.Parameters.AddWithValue("@currentAddress", mpDetailsBO.currentAddress);
            cmd.Parameters.AddWithValue("@currentDistrictId", mpDetailsBO.currentDistrictId);
            cmd.Parameters.AddWithValue("@currentStateId", mpDetailsBO.currentStateId);
            SqlParameter message = cmd.Parameters.Add("@message", SqlDbType.Bit);
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
    public DataTable loadDistrict(byte stateId)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "selectDistrict";
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@stateId", stateId);
            DataSet ds = new DataSet();
            dap.Fill(ds, "district");
            dap.Dispose();
            return (ds.Tables["district"]);
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
    public DataTable loadConstituency( byte stateId)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "CONSTITUENCY_FETCHING";
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@stateId", stateId);
            DataSet ds = new DataSet();
            dap.Fill(ds, "constituency");
            dap.Dispose();
            return (ds.Tables["constituency"]);
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


    public DataTable loadParty(int countryId)
    {
        try
        {
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            query = "selectPartyBasedOnCountry";
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType= CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@countryID",countryId);
            DataSet ds = new DataSet();
            dap.Fill(ds, "party");
            dap.Dispose();
            return (ds.Tables["party"]);
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
    public DataTable loadState(int countryId)
    {
        try
        {
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            query = "selectStateBasedOnCountry";
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@countryID", countryId);
            DataSet ds = new DataSet();
            dap.Fill(ds,"state");
            dap.Dispose();
            return ds.Tables["state"];
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

    public DataTable loadCountry()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            query = "selectCountry";
            dap = new SqlDataAdapter(query, con);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            dap.Fill(ds, "country");
            dap.Dispose();// release all the resources used by data adaptor
            return ds.Tables["country"];

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