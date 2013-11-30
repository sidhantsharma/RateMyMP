using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for countryBAL
/// </summary>
public class countryBAL
{
    countryDAL CountryDAL = new countryDAL();
    public bool countryInsert(countryBO countryBO)
    {
        try
        {
          return  CountryDAL.countryInsert(countryBO);
         
        }
        catch
        {
            throw;
        }
        finally 
        {
            
        }
    }



    public DataTable load_country()
    {
        try
        {
            return CountryDAL.load_country();

        }
        catch
        {
            throw;
        }
        finally
        {

        }
    }
}
