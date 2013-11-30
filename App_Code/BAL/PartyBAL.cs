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
public class PartyBAL
{
    public PartyDAL ob = new PartyDAL();
    public PartyBAL()
    {
    }
    public bool partyInsert(partyBO PartyBO)
    {
        try
        {
            return ob.partyInsert(PartyBO);
        }
        catch
        {
            throw;
        }
        finally { }

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


    public DataTable getData(partyBO PartyBO)
    {
        try
        {
            return ob.getData(PartyBO);
        }
        catch
        {
            throw;
        }
        finally
        {
        }
    }



    public void partyUpdate(partyBO PartyBO)
    {
        try
        {
            ob.partyUpdate(PartyBO);
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
