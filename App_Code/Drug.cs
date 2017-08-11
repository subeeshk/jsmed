using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for Drug
/// </summary>

// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Drug : System.Web.Services.WebService
{
    private DataSet dataTable;

    public Drug()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]

    public string HelloWorld(string name)
    {
        
      

        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=YEAR1718;User ID=sa;Password=sa:123"))
        {
            using (SqlCommand cmd = new SqlCommand("select top 50 Prodcode, it_name,It_CurStock,RackNo from itemmaster where It_Name like '" + name+"%'", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }
                return serializer.Serialize(rows);


            }

        }
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]

    public string Details(string name)
    {



        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=YEAR1718;User ID=sa;Password=sa:123"))
        {
            using (SqlCommand cmd = new SqlCommand("select SupplierMaster.SupplierName,SupplierMaster.Address1,SupplierMaster.Address2,SupplierMaster.Phone from Itemmaster left join SupplierMaster on Itemmaster.SupplierCode= SupplierMaster.SupplierID where Itemmaster.Prodcode='" + name+"'", con))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }
                return serializer.Serialize(rows);


            }

        }
    }

}