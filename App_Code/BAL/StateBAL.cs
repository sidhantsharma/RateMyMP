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
public class StateBAL
{
    public StateDAL ob = new StateDAL();
    public StateBAL()
    {
    }
    public bool stateInsert(stateBO StateBO)
    {
        try
        {
           return ob.stateInsert(StateBO);
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

    public void updateState(stateBO StateBO)
    {
        try
        {
            ob.updateState(StateBO);

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
