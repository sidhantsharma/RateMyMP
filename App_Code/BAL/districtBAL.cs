using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for districtBAL
/// </summary>
public class districtBAL
{
    districtDAL districtDAL = new districtDAL();
	public districtBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool districtInsert(districtBO districtBO)
    {
        try
        {
            return districtDAL.districtInsert(districtBO);
        }
        catch
        {
            throw;
        }
        finally
        {

        }
    }


    public void districtUpdate(districtBO districtBO)
    {
        try
        {
            districtDAL.districtUpdate(districtBO);
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