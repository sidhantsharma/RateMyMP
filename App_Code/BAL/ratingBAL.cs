using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ratingBAL
/// </summary>
public class ratingBAL
{
    private ratingDAL ratingdal = new ratingDAL();
	public ratingBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable getrating(Int64 mpId, Int16 paramId=0, Int64 guId=0, Int16 rating=0)
    {
        try
        {
            return ratingdal.getRating(mpId,paramId,guId, rating);
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