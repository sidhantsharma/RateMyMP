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
/// <summary>

/// </summary>
public class ConstituencyBAL
{
    private ConstituencyDAL ob = new ConstituencyDAL();
    public ConstituencyBAL()
    {
    }
    public bool checkMpExistOrNot(Int16 constituencyId)
    {
        try
        {
            return ob.checkMpExistOrNot(constituencyId);
        }
        catch
        {
            throw;
        }
        finally
        {

        }

    }

    public bool constituencyInsert(constituencyBO constituencyBO)
    {
        try
        {
            return ob.constituencyInsert(constituencyBO);
        }
        catch
        {
            throw;
        }
        finally
        {

        }

            
    }
    
    public DataTable getData()
    {
        try
        {
            return ob.getData();
        }
        catch
        {
            throw;
        }
        finally
        {
        }
    }
    public DataTable getData(Int16 stateId)
    {
        try
        {

            return (DataTable)ob.getData(stateId);
        }
        catch
        {
            throw;
        }
        finally
        {
        }
    }
    public void updateConstituency(constituencyBO ConstituencyBO)
    {
        try
        {
            ob.updateConstituency(ConstituencyBO);
        }
        catch
        {
            throw;
        }
        finally {
        }
    }

}
