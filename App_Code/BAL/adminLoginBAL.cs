using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for adminLoginBAL
/// </summary>
public class adminLoginBAL
{
    adminLoginDAL adminLoginDAL = new adminLoginDAL();
	public adminLoginBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool adminLoginCheck(adminLoginBO adminLoginBO)
    {
        try
        {
            return (adminLoginDAL.adminLoginCheck(adminLoginBO));
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